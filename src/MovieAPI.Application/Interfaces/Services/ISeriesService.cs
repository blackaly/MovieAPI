using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface ISeriesService
    {
        Task<Result<IEnumerable<Series>>> GetAll();
        Task<Result<Series>> Add(Series series);
        Task<Result<Series>> AddWithEposides(Series series);
        Task<Result<Series>> EditSeries(int id, Series series);
        Task<Result<Series>> GetBy(int id);
        Task<Result<IEnumerable<Series>>> GetBy(string name);

    }
}
