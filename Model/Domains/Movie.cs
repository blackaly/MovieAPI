using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MovieAPI.Model.Domains
{
    [Index(nameof(Title))]
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "You have exceeded the title limit length")]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = "You have exceeded the discription limit length")]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [MaxLength(1000, ErrorMessage="You have exceeded the discription limit length")]
        public string StoreLine { get; set; }
        public byte[] Poster { get; set; }
        public byte GenreId { get; set; }
        public ICollection<WatchListMoviesSeries> WatchListMoviesSeries { get; set; }
        ICollection<MovieGenreies> MovieGenreies { get; set; }
    }
}
