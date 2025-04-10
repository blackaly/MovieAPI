using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Infrastructure.Persistence;

namespace MovieAPI.Infrastructure.Repository
{
    public class DirectorRepository : IDirectorRepo 
    {
        private readonly ApplicationDbContext _context;
        public DirectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Director> Add(Director entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Director director)
        {
            _context.Directors.Remove(director);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetBy(int id)
        {
            var obj = await _context.Directors.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Director>> GetBy(string name)
        {
            return _context.Directors.Where(x =>
            string.Concat(x.FirstName, " ", x.LastName).
            ToLower().Trim()
            .Contains(name.ToLower()));
        }

        public async Task<IEnumerable<Director>> GetSeriesDirectors(int id)
        {
            return (IEnumerable<Director>)_context.SeriesDirectors.Where(x => x.DirectorId == id).Include(y => y.Director);
        }

        public async Task<IEnumerable<Director>> GetSeriesDirectors(string name)
        {
            return (IEnumerable<Director>)_context.SeriesDirectors.Where(x => string
                    .Concat(x.Director.FirstName, " ", x.Director.LastName).ToLower()
                    .Contains(name.ToLower())).Include(y => y.Director);
        }

        public async Task<Director> Update(Director updated)
        {
            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updated;
        }
    }
}
