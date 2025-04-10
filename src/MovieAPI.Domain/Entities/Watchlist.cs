namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class Watchlist
    {
        public int WatchlistId { get; set; }
        public int ApplicationUserId { get; set; } 
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<WatchListMoviesSeries> WatchListMoviesSeries { get; set; }
        public string WatchlistName { get; set; }
    }
}
