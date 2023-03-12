using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll(); 
        Task<Movie> Add(Movie movie);
        Task<bool> IsMovieExists<T>(T param);
        Task<Movie> GetBy<T>(T param);
    }
}
