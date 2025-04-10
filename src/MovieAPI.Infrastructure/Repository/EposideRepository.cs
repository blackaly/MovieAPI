using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.Migrations;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MovieAPI.Infrastructure.Repository
{
    public class EposideRepository : IEposideRepo
    {
        private readonly ApplicationDbContext _context;
        public EposideRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Eposide>> Add(List<Eposide> eposide)
        {
            await _context.Eposides.AddRangeAsync(eposide);
            await _context.SaveChangesAsync();
            return eposide;
        }

        public async Task<Eposide> Add(Eposide entity)
        {
            await _context.Eposides.AddAsync(entity);
            if(await _context.SaveChangesAsync() > 0) return entity;
            return null;
        }

        public async Task<bool> Delete(Eposide entity)
        {
            _context.Eposides.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Eposide>> GetAll()
        {
            return await _context.Eposides.ToListAsync();
        }

        public async Task<Eposide> GetBy(int id)
        {
            return await _context.Eposides.FindAsync(id);
        }

        public async Task<IEnumerable<Eposide>> GetBy(string name)
        {
            return await _context.Eposides.Where(x => x.EposideName.ToLower() == name.ToLower().Trim()).ToListAsync();
        }

        public async Task<IEnumerable<Eposide>> GetByToListAsync(string name)
        {
            return await _context.Eposides.Where(x => x.EposideName.ToLower() == name.ToLower().Trim()).ToListAsync();
        }

        public async Task<IEnumerable<Eposide>> GetEposideWithSeriesiD(int id)
        {
            return await _context.Eposides.Where(x => x.SeriesId == id).ToListAsync();
        }

        public async Task<IEnumerable<Eposide>> GetEposideWithSeriesName(string name)
        {
            return await _context.Eposides.Where(x => x.Series.Title.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<Eposide> Update(Eposide entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
