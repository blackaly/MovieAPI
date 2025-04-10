using MovieAPI.src.MovieAPI.Domain.Entities;using Microsoft.AspNetCore.Http;

namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class RatingDTO
    {
        public decimal RatingScore { get; set; }
        public DateTime RatingDate { get; set; }
        public int ApplicationUserId { get; set; }
        public int MovieId { get; set; }
        public int SeriesId { get; set; }
    }
}

