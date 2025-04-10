using MovieAPI.src.MovieAPI.Domain.Entities;using Microsoft.AspNetCore.Http;

namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class WatchlistDTO
    {
        public int ApplicationUserId { get; set; }
        public string WatchlistName { get; set; }
    }
}

