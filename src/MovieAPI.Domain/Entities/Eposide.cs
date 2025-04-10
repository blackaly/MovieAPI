using System.Text.Json.Serialization;

namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class Eposide
    {
        public int EposideId { get; set; }
        public string EposideName { get; set; } 
        public string? EposideDiscription { get; set; }
        public string? EposideImageUrl { get; set; }
        public int SeriesId { get; set; }
        [JsonIgnore]
        public virtual Series Series { get; set; }
    }
}
