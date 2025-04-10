namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class SeriesDirectors
    {
        public int SeriesDirectorsId { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
