using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Infrastructure.Persistence;

namespace MovieAPI.Infrastructure.Repository
{
    public class GenreRepository : IGenreRepo
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Genre> Add(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0) return entity;
            return null;
        }

        public async Task<bool> Delete(Genre entity)
        {
            _context.Genres.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetBy(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genre> GetBy(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<Genre> Update(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
