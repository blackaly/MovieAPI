using Microsoft.AspNetCore.Http;
namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class DirectorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? Bio { get; set; }
    }
}


