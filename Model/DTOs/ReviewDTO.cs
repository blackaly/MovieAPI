using MovieAPI.Model.Domains;

namespace MovieAPI.Model.DTOs
{
    public class ReviewDTO
    {
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ApplicationUserId { get; set; }
        public int MovieId { get; set; }
        public int SeriesId { get; set; }
    }
}
