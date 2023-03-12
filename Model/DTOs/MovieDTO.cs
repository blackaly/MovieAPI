using MovieAPI.Model.Domains;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Model.DTOs
{
    public class MovieDTO
    {
        [MaxLength(200, ErrorMessage = "You have exceeded the title limit length")]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = "You have exceeded the discription limit length")]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [MaxLength(1000, ErrorMessage = "You have exceeded the discription limit length")]
        public string StoreLine { get; set; }
        public IFormFile Poster { get; set; }
        public byte GenreId { get; set; }
    }
}
