namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class SeriesGenres
    {
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
    }
}
