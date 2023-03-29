using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;

namespace MovieAPI.Services.Implementation
{
    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext _context;


        public DirectorService(ApplicationDbContext context)
        {
                _context= context;
        }

        public async Task<Director> Add(Director director)
        {
            await _context.AddAsync(director);
            await _context.SaveChangesAsync();

            return director;
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

        public IEnumerable<Director> GetBy(string name)
        {
            return _context.Directors.Where(x => 
            string.Concat(x.FirstName, " ", x.LastName).
            ToLower()
            .Contains(name.ToLower()));
        }

        public IEnumerable<Director> GetSeriesDirectors(int id)
        {
            return (IEnumerable<Director>)_context.SeriesDirectors.Where(x => x.DirectorId == id).Include(y => y.Director);
        }

        public IEnumerable<Director> GetSeriesDirectors(string name)
        {
            return (IEnumerable<Director>)_context.SeriesDirectors.Where(x => string
            .Concat(x.Director.FirstName, " ", x.Director.LastName).ToLower()
            .Contains(name.ToLower())).Include(y => y.Director);
        }
    }
}
