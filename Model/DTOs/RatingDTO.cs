using MovieAPI.Model.Domains;

namespace MovieAPI.Model.DTOs
{
    public class RatingDTO
    {
        public decimal RatingScore { get; set; }
        public DateTime RatingDate { get; set; }
        public int ApplicationUserId { get; set; }
        public int MovieId { get; set; }
        public int SeriesId { get; set; }
    }
}
