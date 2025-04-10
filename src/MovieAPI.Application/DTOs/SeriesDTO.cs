using MovieAPI.src.MovieAPI.Domain.Entities;using Microsoft.AspNetCore.Http;

namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class SeriesDTO
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public IFormFile PosterImage { get; set; }
        public string TrailerVideoURL { get; set; }
        public string RuntimeperEpisode { get; set; }
        public string Language { get; set; }
        public string ProductionStudio { get; set; }
        public decimal Budget { get; set; }
        public decimal BoxOfficeRevenue { get; set; }
    }
}

