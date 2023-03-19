namespace MovieAPI.Model.Domains
{
    public class SeriesDirectors
    {
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
