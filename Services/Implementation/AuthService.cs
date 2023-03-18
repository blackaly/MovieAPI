using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.JWT;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Model.Enums;
using MovieAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtMapping _jwt; 

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtMapping> jwt) {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> Login(LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthModel() { Message = "Password or email is not correct" };
            }

            var token = await CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            var auth = new AuthModel()
            {
                Email = user.Email,
                Expiration = token.ValidTo,
                IsAuthenticated = true,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName

            };

            return auth; 

        }

        public async Task<AuthModel> Register(RegisterationModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return new AuthModel() { Message = "Email is already exists" };

            if (await _userManager.FindByNameAsync(model.Username) != null)
                return new AuthModel() { Message = "Username is already exists" };


            var usr = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                Name = model.FirtName + " " + model.LastName
            };

            var res = await _userManager.CreateAsync(usr, model.Password);

            if (!res.Succeeded)
            {
                string errors = string.Empty;
                foreach (var err in res.Errors) errors += err.Code + "\n";
                return new AuthModel() { Message = errors };
            }

            await _userManager.AddToRoleAsync(usr, nameof(Roles.User));

            var token = await CreateJwtToken(usr);

            var auth = new AuthModel()
            {
                Email = model.Email,
                Username = model.Username,
                Expiration = token.ValidTo,
                IsAuthenticated = true,
                Message = string.Empty,
                Roles = new List<string>() { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(token)
                
            };

            return auth;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
