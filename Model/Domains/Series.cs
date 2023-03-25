using NuGet.DependencyResolver;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace MovieAPI.Model.Domains
{
    public class Series
    {
        public int SeriesId { get; set; }
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
        [JsonIgnore]
        public ICollection<WatchListMoviesSeries>? WatchListMoviesSeries { get; set; }
        [JsonIgnore]
        public ICollection<Eposide>? Eposides{ get; set; }
    }
}
