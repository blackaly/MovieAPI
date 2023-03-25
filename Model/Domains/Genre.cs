using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Model.Domains
{
    [Index(nameof(Name))]
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(100, ErrorMessage = "You have exceeded the max length")]
        public string Name { get; set; }

        ICollection<MovieGenres> MovieGenreies { get; set; }
    }
}
