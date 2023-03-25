namespace MovieAPI.Model.Domains
{
    public class Rating
    {
        public int RatingId { get; set; }
        public decimal RatingScore { get; set; }
        public DateTime RatingDate { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }

        
    }
}
