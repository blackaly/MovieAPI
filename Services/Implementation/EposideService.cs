using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;
using System.Runtime.Remoting;

namespace MovieAPI.Services.Implementation
{
    public class EposideService : IEposideService
    {

        private readonly ApplicationDbContext _context;
        private readonly ISeriesService _seriesService;
        public EposideService(ApplicationDbContext context, ISeriesService seriesService)
        {
            _context = context;
            _seriesService = seriesService;
        }

        public async Task<IEnumerable<Eposide>> Add(int id, List<Eposide> eposide)
        {

            var obj = await _seriesService.GetBy(id);

            if (obj == null) return null;

            obj.Eposides = eposide;
            await _context.Eposides.AddRangeAsync(eposide);

            await _context.SaveChangesAsync();
            return obj.Eposides; 
            
        }

        public async Task EditEposide(Eposide eposide)
        {
            _context.Entry(eposide).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Eposide>> GetAll()
        {
            return await _context.Eposides.ToListAsync();
        }

        public async Task<Eposide> GetBy(int id)
        {
            return await _context.Eposides.FindAsync(id);
        }

        public IEnumerable<Eposide> GetBy(string name)
        {
            return  _context.Eposides.Where(x => x.EposideName.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<Eposide> GetEposideWithSeriesiD(int id)
        {
            return _context.Eposides.Where(x => x.SeriesId == id);
        }

        public IEnumerable<Eposide> GetEposideWithSeriesName(string name)
        {
            return _context.Eposides.Where(x => x.Series.Title.ToLower().Contains(name.ToLower()));
        }

    }
}
