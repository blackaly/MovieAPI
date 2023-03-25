using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;

namespace MovieAPI.Services.Implementation
{
    public class SeriesService : ISeriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEposideService eposideService;
        public SeriesService(ApplicationDbContext context, IEposideService eposideService)
        {
            _context = context;
            this.eposideService = eposideService;
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

        public async Task<IEnumerable<Series>> GetAll()
        {
            return await _context.Series.Include(x => x.Eposides).ToListAsync(); 
        }

        public Task<Series> GetBy<T>(T param)
        {
            throw new NotImplementedException();
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
