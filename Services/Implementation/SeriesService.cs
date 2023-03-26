using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;

namespace MovieAPI.Services.Implementation
{
    public class SeriesService : ISeriesService
    {
        private readonly ApplicationDbContext _context;
        public SeriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Series> Add(Series series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
            return series;
        }

        public async Task<Series> AddWithEposides(Series series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();

            return series;
        }

        public Task<Series> EditSeries(int id, Series series)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Series>> GetAll()
        {
            return await _context.Series.Include(x => x.Eposides).ToListAsync(); 
        }

        public async Task<Series> GetBy(int id)
        {

            return await _context.Series.AsNoTracking().FirstOrDefaultAsync(x => x.SeriesId == id);
        }

        public IEnumerable<Series> GetBy(string name)
        {
            return  _context.Series.AsNoTracking().Where(x => x.Title.ToLower().Contains(name.ToLower()));
        }

        public Task<IEnumerable<Series>> GetSeriesWithItsEposides(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Series>> GetSeriesWithItsEposidesName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSeriesExists<T>(T param)
        {
            throw new NotImplementedException();
        }
    }
}
