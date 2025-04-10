using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorService _directorService;
        private IWebHostEnvironment _webHostEnvironment;
        public DirectorController(IDirectorService directorService, IWebHostEnvironment webHostEnvironment)
        {
            _directorService = directorService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var obj = await _directorService.GetAll();

            if (!obj.IsSuccess || !obj.Value.Any()) return NoContent();

            return Ok(obj.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromForm]DirectorDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var fake = Path.GetRandomFileName(); 

            Director d = new Director()
            {
                Bio = model.Bio,
                Country = model.Country,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePicture = fake,
            };

            if (!string.IsNullOrEmpty(model.ProfilePicture?.FileName))
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fake);
                using FileStream f = new FileStream(path, FileMode.Create);
                model.ProfilePicture.CopyTo(f);
            }

            try
            {
                var output = await _directorService.Add(d);

                return Ok(output);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
