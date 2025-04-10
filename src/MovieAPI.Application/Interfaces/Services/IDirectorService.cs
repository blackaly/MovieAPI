using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Domain.Common;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface IDirectorService
    {
        Task<Result<IEnumerable<Director>>> GetAll();
        Task<Result<Director>> GetBy(int id);
        Task<Result<IEnumerable<Director>>> GetBy(string name);
        Task<Result<Director>> Add(Director director);
        Task<Result<IEnumerable<Director>>> GetSeriesDirectors(int id);
        Task<Result<IEnumerable<Director>>> GetSeriesDirectors(string name);
    }
}
