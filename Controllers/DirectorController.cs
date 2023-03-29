using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model.Domains;
using MovieAPI.Model.DTOs;
using MovieAPI.Services.Implementation;
using MovieAPI.Services.Interfaces;

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

            if (obj.Count() <= 0) return NoContent();

            return Ok(obj);
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
                await _directorService.Add(d);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
