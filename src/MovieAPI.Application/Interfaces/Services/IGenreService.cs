using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface IGenreService
    {
        Task<Result<IEnumerable<Genre>>> GetAll();
        Task<Result<Genre>> Add(Genre genre);
        Task<Result<Genre>> GetBy(int id);
        Task<Result<Genre>> GetBy(string name);
        Task<Result<bool>> Delete(Genre genre);
        Task<Result<bool>> Update(Genre genre);
        
        // Added methods to match controller expectations
        Task<bool> isGenereExists(byte id);
        Task<bool> isGenereExists(string name);
        Task<Genre> GetGenreById(byte id);
    }
}
