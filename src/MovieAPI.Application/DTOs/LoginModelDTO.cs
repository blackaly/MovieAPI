using System.ComponentModel.DataAnnotations;

namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class LoginModelDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

