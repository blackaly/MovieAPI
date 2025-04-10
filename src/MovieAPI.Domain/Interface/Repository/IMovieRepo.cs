using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Interface.Repository
{
    public interface IMovieRepo : BaseInterface<Movie>
    {
        Task<Movie> GetBy(int id);
        Task<IEnumerable<Movie>> GetBy(string name);
    }
}
