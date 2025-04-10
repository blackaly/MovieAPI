using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using System.Runtime.Remoting;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {

        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        } 


        [HttpGet]
        public async Task<IActionResult> GetAllGenersAsync()
        {
            var obj = await _genreService.GetAll(); 

            if (!obj.IsSuccess || !obj.Value.Any()) return NoContent();
            return Ok(obj.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGenersAsync(GenresDTO dto)
        {
            if (dto == null) return NoContent();
            else if (await _genreService.isGenereExists(dto.Name)) return Conflict();

            var obj = new Genre { Name = dto.Name };

            try 
            {  return Ok(await _genreService.Add(obj)); } 
            catch
            {
                return BadRequest();
            }
 
        }

        [HttpPut]

        public async Task<IActionResult> PutGenereAsync([FromQuery] byte id, [FromBody] GenresDTO dto)
        {
            if (dto == null) return NoContent();
            var obj = await _genreService.GetGenreById(id);
            if (obj == null) return NoContent();

            obj.Name = dto.Name;


            try
            {
                await _genreService.Update(obj);
                return Ok();
            }
            catch
            {
                return BadRequest(); 
            }

        }

        [Route("genreExists")]
        [HttpGet]
        public async Task<IActionResult> GenereExists(string name)
        {
            if (name.IsNullOrEmpty()) return BadRequest();

            if (await _genreService.isGenereExists(name)) return Ok();
            return NotFound($"No genere was found with name {name}");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteGenre(byte id)
        {
            if (id == 0) return BadRequest();

            var obj = await _genreService.GetGenreById(id);
            if(obj != null)
            {
                await _genreService.Delete(obj);
                return Ok(); 
            }return NotFound();
        }
    }
}
