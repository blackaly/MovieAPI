namespace MovieAPI.Model.Domains
{
    public class Watchlist
    {
        public int WatchlistId { get; set; }
        public int ApplicationUserId { get; set; } 
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string WatchlistName { get; set; }
    }
}
