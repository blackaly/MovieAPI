namespace MovieAPI.Model.Domains
{
    public class WatchListMoviesSeries
    {
        public int WatchListMoviesSeriesId { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie{ get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }  
    }
}
