using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;
using System.Reflection;

namespace MovieAPI.Services.Implementation
{
    public class MovieService : IMovieService
    {

        private readonly ApplicationDbContext _db;

        public MovieService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Movie> Add(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> GetBy<T>(T param)
        {
            if (typeof(T).Name.ToLower().Equals("string"))
                return await _db.Movies.FirstOrDefaultAsync(x => x.Title == param.ToString());
            else
                return await _db.Movies.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(param));
        }

        public async Task<bool> IsMovieExists<T>(T param)
        {
            if (typeof(T).Name.ToLower().Equals("string"))
                return await _db.Movies.AnyAsync(x => x.Title == param.ToString());
            else
                return await _db.Movies.AnyAsync(x => x.Id == Convert.ToInt32(param));
        }
    }
}
