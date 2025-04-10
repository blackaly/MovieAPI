using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.src.MovieAPI.Application.Interfaces.Services
{
    public interface IEposideService
    {
        Task<Result<IEnumerable<Eposide>>> GetAll();
        Task<Result<IEnumerable<Eposide>>> GetEposideWithSeriesiD(int id);
        Task<Result<IEnumerable<Eposide>>> GetEposideWithSeriesName(string name);
        Task<Result<IEnumerable<Eposide>>> Add(int id, List<Eposide> eposide);
        Task<Result<Eposide>> Add(int id, Eposide eposide);
        Task<Result<Eposide>> EditEposide(Eposide eposide);
        Task<Result<Eposide>> GetBy(int id);
        Task<Result<IEnumerable<Eposide>>> GetBy(string name);
    }
}
