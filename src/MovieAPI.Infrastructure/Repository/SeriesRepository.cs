using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repository
{
    public class SeriesRepository : ISeriesRepo
    {
        private readonly ApplicationDbContext _context;
        public SeriesRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Series> Add(Series entity)
        {
            await _context.Series.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0? entity: null;
        }

        public async Task<bool> Delete(Series entity)
        {
            _context.Series.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Series>> GetAll()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Series> GetBy(int id)
        {
            return await _context.Series.Include(x => x.Eposides).Where(x => x.SeriesId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Series>> GetBy(string title)
        {
            return await _context.Series.Include(x => x.Eposides).Where(x => x.Title.ToLower().Trim() == title.ToLower().Trim()).ToListAsync();
        }

        public async Task<IEnumerable<Series>> GetSeriesWithItsEposides(int id)
        {
            return await _context.Series.Include(x => x.Eposides).Where(x => x.SeriesId == id).ToListAsync();   
        }

        public async Task<IEnumerable<Series>> GetSeriesWithItsEposidesName(string title)
        {
            return await _context.Series.Include(x => x.Eposides).Where(x => x.Title.ToLower().Trim() == title.ToLower().Trim()).ToListAsync();
        }

        public async Task<Series> Update(Series entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
