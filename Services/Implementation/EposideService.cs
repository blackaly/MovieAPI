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

        public Task<Eposide> EditSeries(int id, Eposide eposide)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Eposide>> GetAll()
        {
            return await _context.Eposides.ToListAsync();
        }

        public Task<Eposide> GetBy<T>(T param)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Eposide>> GetEposideWithSeries(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Eposide>> GetEposideWithSeriesName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSeriesExists<T>(T param)
        {
            throw new NotImplementedException();
        }
    }
}
