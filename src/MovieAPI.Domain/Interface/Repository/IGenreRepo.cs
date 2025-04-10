using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Interface.Repository
{
    public interface IGenreRepo : BaseInterface<Genre>
    {
        Task<Genre> GetBy(int id);
        Task<Genre> GetBy(string name);
    }
}
