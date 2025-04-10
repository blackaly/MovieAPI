namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class MovieDirectors
    {
        public int MovieDirectorsId { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int DirectorId { get; set; } 
        public virtual Director Director { get; set; }
    }
}
