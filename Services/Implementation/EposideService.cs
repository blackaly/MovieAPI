using MovieAPI.Model.Domains;
using MovieAPI.Services.Interfaces;

namespace MovieAPI.Services.Implementation
{
    public class EposideService : IEposideService
    {
        public Task<Eposide> Add(int id, Eposide eposide)
        {
            throw new NotImplementedException();
        }

        public Task<Eposide> EditSeries(int id, Eposide eposide)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Eposide>> GetAll()
        {
            throw new NotImplementedException();
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
