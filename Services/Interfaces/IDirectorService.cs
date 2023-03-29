using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> GetAll();
        Task<Director> GetBy(int id);
        IEnumerable<Director> GetBy(string name);
        Task<Director> Add(Director director);
        IEnumerable<Director> GetSeriesDirectors(int id);
        IEnumerable<Director> GetSeriesDirectors(string name);
    }
}
