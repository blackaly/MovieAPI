using MovieAPI.Model.Domains;

namespace MovieAPI.Model.DTOs
{
    public class EposideDTO
    {
        public string EposideName { get; set; }
        public string? EposideDiscription { get; set; }
        public string? EposideImageUrl { get; set; }
        public int? SeriesId { get; set; }
    }
}
