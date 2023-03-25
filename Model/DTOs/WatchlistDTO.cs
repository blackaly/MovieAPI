using MovieAPI.Model.Domains;

namespace MovieAPI.Model.DTOs
{
    public class WatchlistDTO
    {
        public int ApplicationUserId { get; set; }
        public string WatchlistName { get; set; }
    }
}
