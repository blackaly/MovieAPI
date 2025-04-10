using System.ComponentModel.DataAnnotations;

namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class RegisterationModelDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "You excceed the max length of the name which is 50 characters")]
        public string FirtName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "You excceed the max length of the name which is 50 characters")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "You excceed the max length of the name which is 50 characters")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

