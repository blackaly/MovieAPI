using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;

namespace MovieAPI.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _db;

        public GenreService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Genre> Add(Genre genre)
        {
            await _db.Genres.AddAsync(genre);
            await _db.SaveChangesAsync();

            return genre;
        }

        public async Task Delete(Genre genre)
        {
            _db.Genres.Remove(genre);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _db.Genres.AsNoTracking().ToListAsync();
        }

        public async Task<Genre> GetGenreById(byte id)
        {
            var obj = await _db.Genres.FindAsync(id);

            return obj;

        }

        public async Task Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }

        public async Task<bool> isGenereExists(string name)
        {
            return await _db.Genres.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> isGenereExists(byte id)
        {
            return await _db.Genres.AnyAsync(x => x.Id == id);
        }
    }
}
