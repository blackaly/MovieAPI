namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class SeriesWithEposideDTO
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
        public ICollection<EposideDTO> Eposides { get; set; }
    }
}

