using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieAPI.src.MovieAPI.Domain.Entities;using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.src.MovieAPI.Application.DTOs
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

