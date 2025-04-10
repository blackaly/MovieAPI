using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Services;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using System.Runtime.Remoting;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EposideController : ControllerBase
    {
        private readonly IEposideService _eposideService;
        private IWebHostEnvironment _webHostEnvironment;
        public EposideController(IEposideService eposideService, IWebHostEnvironment webHostEnvironment)
        {
            _eposideService = eposideService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEposides()
        {
            var result = await _eposideService.GetAll();

            if (!result.IsSuccess || !result.Value.Any()) 
                return NoContent();

            return Ok(result.Value);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEposide(int id, List<EposideDTO> eposides)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<Eposide> ep = new List<Eposide>();
            var fakeFile = Path.GetRandomFileName();
            foreach (var o in eposides)
            {
                ep.Add(new Eposide() { 
                    EposideDiscription = o.EposideDiscription,
                    EposideImageUrl = fakeFile,
                    EposideName = o.EposideName,
                    SeriesId = o.SeriesId
                });

                if (!string.IsNullOrEmpty(o.EposideImageUrl?.FileName))
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fakeFile);
                    using FileStream f = new FileStream(path, FileMode.Create);
                    o.EposideImageUrl.CopyTo(f);
                }
            }

            var result = await _eposideService.Add(id, ep);
            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost("single")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEposideOneByOne([FromQuery] int id, [FromForm]EposideDTO eposides)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Eposide ep = new Eposide();
            var fakeFile = Path.GetRandomFileName();

            ep.EposideDiscription = eposides.EposideDiscription;
            ep.EposideImageUrl = fakeFile;
            ep.EposideName = eposides.EposideName;
            ep.SeriesId = id;
               
            if (!string.IsNullOrEmpty(eposides.EposideImageUrl?.FileName))
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fakeFile);
                using FileStream f = new FileStream(path, FileMode.Create);
                eposides.EposideImageUrl.CopyTo(f);
            }
            
            var result = await _eposideService.Add(id, ep);
            if (!result.IsSuccess)
                return BadRequest(result.Errors);
                
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> EditEposide([FromQuery]int id, [FromForm]EposideDTO eposide)
        {
            try
            {
                var result = await _eposideService.GetBy(id);
                if (!result.IsSuccess) 
                    return BadRequest("There is no eposide with this id");

                var obj = result.Value;

                if(!string.IsNullOrEmpty(eposide.EposideDiscription))
                    obj.EposideDiscription = eposide.EposideDiscription;
                
                if(eposide.SeriesId != 0)
                    obj.SeriesId = eposide.SeriesId;
                
                if(!string.IsNullOrEmpty(eposide.EposideName))
                    obj.EposideName = eposide.EposideName;

                if (!string.IsNullOrEmpty(eposide.EposideImageUrl?.FileName))
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", obj.EposideImageUrl);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    var fake = Path.GetRandomFileName();
                    obj.EposideImageUrl = fake;
                    using FileStream f = new FileStream(path, FileMode.Create);
                    eposide.EposideImageUrl.CopyTo(f);
                }

                var editResult = await _eposideService.EditEposide(obj);
                if (!editResult.IsSuccess)
                    return BadRequest(editResult.Errors);

                return Ok(editResult.Value);
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetEposideyId(int id)
        {
            var result = await _eposideService.GetBy(id);

            if (!result.IsSuccess) return NoContent();

            return Ok(result.Value);
        }

        [HttpGet("ByName")]
        public async Task<IActionResult> GetEposideyName(string name)
        {
            var result = await _eposideService.GetBy(name);
            if (!result.IsSuccess || !result.Value.Any()) 
                return NoContent();
                
            return Ok(result.Value);
        }

        [HttpGet("BySeriesId")]
        public async Task<IActionResult> GetEposideBySeriesId(int id)
        {
            var result = await _eposideService.GetEposideWithSeriesiD(id);
            if (!result.IsSuccess || !result.Value.Any()) 
                return NoContent();
                
            return Ok(result.Value);
        }

        [HttpGet("BySeriesName")]
        public async Task<IActionResult> GetEposideBySeriesName(string name)
        {
            var result = await _eposideService.GetEposideWithSeriesName(name);
            if (!result.IsSuccess || !result.Value.Any()) 
                return NoContent();
                
            return Ok(result.Value);
        }
    }
}
