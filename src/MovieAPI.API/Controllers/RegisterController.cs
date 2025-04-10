using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterationModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            if (!model.Password.Equals(model.ConfirmPassword)) return BadRequest("Password not matched"); 

            var res = await _authService.Register(model);

            if (!res.IsAuthenticated) { return BadRequest(res.Message); }

            return Ok(res);
        }

        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginModelDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _authService.Login(model);

            if(!res.IsAuthenticated) return BadRequest(res.Message);

            return Ok(res);
        }
    }
}
