using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Services;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;



        private List<string> AllowedExtensionsDomain;
        private const int MAXFILESIZE = 524_288_000;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
            AllowedExtensionsDomain = new List<string>() { ".png", ".jpg", ".jpeg" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm]MovieDTO dto)
        {
            if (dto == null) return BadRequest();
            else if(!ModelState.IsValid) { return BadRequest(ModelState); }

            if (!this.AllowedExtensionsDomain.Contains(Path.GetExtension(dto.Poster.FileName.ToLower())))
                return BadRequest("The file extension must be .png, .jpg or .jpeg");
            else if (dto.Poster.Length > MAXFILESIZE)
                return BadRequest($"This file must be less than or equal to {MoviesController.MAXFILESIZE}");

            if(!await _genreService.isGenereExists(dto.GenreId)) { return NotFound("Invalid Genre ID"); }

            using(var dataStream = new MemoryStream())
            {
                await dto.Poster.CopyToAsync(dataStream);

                var movie = new Movie()
                {
                   Title= dto.Title,
                   Date= dto.Date,
                   StoreLine= dto.StoreLine,
                   Description= dto.Description,
                   GenreId= dto.GenreId,
                   Poster = dataStream.ToArray(),
                };

                return Ok(await _movieService.Add(movie));

            }
        }

        [HttpPost("MovieByName")]
        public async Task<IActionResult> GetMoviesBy(string title)
        {
            if (title.IsNullOrEmpty()) return NoContent();
            
            var result = await _movieService.GetBy(title);
            if (!result.IsSuccess) return NotFound();

            return Ok(result);
        }

        [HttpPost("MovieById")]
        public async Task<IActionResult> GetMoviesById(int id)
        {
            if (id == 0) return NoContent();
            
            var result = await _movieService.GetBy(id);
            if (!result.IsSuccess) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAll();

            if (movies != null) return Ok(movies);
            return NoContent();
        }

    }
}
