﻿using MovieAPI.Model.Domains;

namespace MovieAPI.Services.Interfaces
{
    public interface ISeriesService
    {
        Task<List<Series>> GetAll();
        Task<IEnumerable<Series>> GetSeriesWithItsEposides(int id);
        Task<IEnumerable<Series>> GetSeriesWithItsEposidesName(string name);
        Task<Series> Add(Series series);
        Task<Series> AddWithEposides(Series series);
        Task<Series> EditSeries(int id, Series series);
        Task<bool> IsSeriesExists<T>(T param);
        Task<Series> GetBy(int id);
        IEnumerable<Series> GetBy(string name);

    }
}
