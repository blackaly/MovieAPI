using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Model.DTOs
{
    public class GenresDTO
    {
        [MaxLength(100, ErrorMessage ="You have exceeded the max length")]
        public string Name { get; set; }
    }
}
