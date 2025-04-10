using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Interface.Repository
{
    public interface IEposideRepo : BaseInterface<Eposide>
    {
        Task<IEnumerable<Eposide>> Add(List<Eposide> eposide);
        Task<Eposide> GetBy(int id);
        Task<IEnumerable<Eposide>> GetBy(string name);
        Task<IEnumerable<Eposide>> GetByToListAsync(string name);
        Task<IEnumerable<Eposide>> GetEposideWithSeriesiD(int id);
        Task<IEnumerable<Eposide>> GetEposideWithSeriesName(string name);
    }
}
