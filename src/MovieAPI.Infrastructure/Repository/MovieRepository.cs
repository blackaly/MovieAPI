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
    public class MovieRepository : IMovieRepo
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Add(Movie entity)
        {
            await _context.Movies.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0) return entity;
            return null;
        }

        public async Task<bool> Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetBy(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetBy(string name)
        {
            return await _context.Movies.Where(x => x.Title.ToLower().Trim() == name.ToLower().Trim()).ToListAsync();
        }

        public async Task<Movie> Update(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
