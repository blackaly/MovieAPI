namespace MovieAPI.Model.Domains
{
    public class Eposide
    {
        public int EposideId { get; set; }
        public string EposideName { get; set; } 
        public string? EposideDiscription { get; set; }
        public string? EposideImageUrl { get; set; }
        public int SeriesId { get; set; }  
        public virtual Series Series { get; set; }
    }
}
