using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> Add(Genre genre);
        Task<Genre> GetGenreById(byte id);

        Task<bool> isGenereExists(string name);
        Task<bool> isGenereExists(byte id);
        Task Delete(Genre genre);
        Task Update(Genre genre);

    }
}
