namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
    }
}
