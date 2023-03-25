using MovieAPI.Model.Domains;

namespace MovieAPI.Model.DTOs
{
    public class SeriesDTO
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public string PosterImage { get; set; }
        public string TrailerVideoURL { get; set; }
        public string RuntimeperEpisode { get; set; }
        public string Language { get; set; }
        public string ProductionStudio { get; set; }
        public decimal Budget { get; set; }
        public decimal BoxOfficeRevenue { get; set; }
    }
}
