using MovieAPI.Model;

namespace MovieAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterationModel model);
    }
}
