using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Interface.Repository
{
    public interface ISeriesRepo : BaseInterface<Series>
    {
        Task<Series> GetBy(int id);
        Task<IEnumerable<Series>> GetBy(string name);
        Task<IEnumerable<Series>> GetSeriesWithItsEposides(int id);
        Task<IEnumerable<Series>> GetSeriesWithItsEposidesName(string name);
    }
}
