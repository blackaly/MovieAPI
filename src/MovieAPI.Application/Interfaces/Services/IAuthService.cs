using MovieAPI.src.MovieAPI.Application.DTOs;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthModelDTO> Register(RegisterationModelDTO model);
        Task<AuthModelDTO> Login(LoginModelDTO model);
    }
}
