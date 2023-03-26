using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface IEposideService
    {
        Task<IEnumerable<Eposide>> GetAll();
        Task<IEnumerable<Eposide>> GetEposideWithSeries(int id);
        Task<IEnumerable<Eposide>> GetEposideWithSeriesName(string name);
        Task<IEnumerable<Eposide>> Add(int id, List<Eposide> eposide);
        Task<Eposide> EditSeries(int id, Eposide eposide);
        Task<bool> IsSeriesExists<T>(T param);
        Task<Eposide> GetBy<T>(T param);
    }
}
