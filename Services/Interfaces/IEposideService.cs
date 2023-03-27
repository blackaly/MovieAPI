using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface IEposideService
    {
        Task<IEnumerable<Eposide>> GetAll();
        IEnumerable<Eposide> GetEposideWithSeriesiD(int id);
        IEnumerable<Eposide> GetEposideWithSeriesName(string name);
        Task<IEnumerable<Eposide>> Add(int id, List<Eposide> eposide);
        Task EditEposide(Eposide eposide);
        Task<Eposide> GetBy(int id);
        IEnumerable<Eposide> GetBy(string name);
    }
}
