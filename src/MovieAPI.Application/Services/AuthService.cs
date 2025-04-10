using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Domain.Enums;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MovieAPI.Infrastructure.Authentication;

namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtGenerator _jwtGenerator;
        public AuthService(UserManager<ApplicationUser> userManager, JwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthModelDTO> Login(LoginModelDTO model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthModelDTO() { Message = "Password or email is not correct" };
            }

            var token = await _jwtGenerator.CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            var auth = new AuthModelDTO()
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

        public async Task<AuthModelDTO> Register(RegisterationModelDTO model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return new AuthModelDTO() { Message = "Email is already exists" };

            if (await _userManager.FindByNameAsync(model.Username) != null)
                return new AuthModelDTO() { Message = "Username is already exists" };


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
                return new AuthModelDTO() { Message = errors };
            }

            await _userManager.AddToRoleAsync(usr, nameof(Roles.User));

            var token = await _jwtGenerator.CreateJwtToken(usr);

            var auth = new AuthModelDTO()
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

    }
}

