using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<Result<IEnumerable<Movie>>> GetAll();
        Task<Result<Movie>> Add(Movie movie);
        Task<Result<Movie>> GetBy(int id);
        Task<Result<IEnumerable<Movie>>> GetBy(string name);
        
        // Added methods to match controller expectations
        Task<bool> IsMovieExists<T>(T identifier);
    }
}
