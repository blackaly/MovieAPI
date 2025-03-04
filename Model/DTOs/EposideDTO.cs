using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieAPI.Model.Domains;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Model.DTOs
{
    public class EposideDTO
    {
        public string EposideName { get; set; }
        public string? EposideDiscription { get; set; }
        public IFormFile? EposideImageUrl { get; set; }
        [BindNever]
        public int SeriesId { get; set; } 
    }
}
