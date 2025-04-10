using Microsoft.EntityFrameworkCore;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Interface.Repository
{
    public interface IDirectorRepo : BaseInterface<Director>
    {
        Task<Director> GetBy(int id);
        Task<IEnumerable<Director>> GetBy(string name);
        Task<IEnumerable<Director>> GetSeriesDirectors(int id);
        public Task<IEnumerable<Director>> GetSeriesDirectors(string name);

    }
}
