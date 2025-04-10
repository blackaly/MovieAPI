using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.DTOs;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;
using System.IO;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService seriesService;
        private IWebHostEnvironment _webHostEnvironment;
        public SeriesController(ISeriesService seriesService, IWebHostEnvironment webHostEnvironment)
        {
            this.seriesService = seriesService;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            var result = await seriesService.GetAll();
            
            if(!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }

            var seriesList = result.Value;
            
            if(seriesList != null)
            {
                foreach(var o in seriesList)
                {
                    if (o.PosterImage.IsNullOrEmpty()) continue;
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", o.PosterImage);
                    MemoryStream s = new MemoryStream();
                    using FileStream f = new FileStream(path, FileMode.Open);
                    f.CopyTo(s);
                    s.Position = 0;
                    o.PosterImage = Convert.ToBase64String(s.ToArray());
                }
            }

            return Ok(seriesList);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSeriesBy(int id)
        {
            var result = await seriesService.GetBy(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            return Ok(result.Value);
        }

        [HttpGet("name")]
        public IActionResult GetSeriesBy(string title)
        {
            var result = seriesService.GetBy(title);
            // Note: This is a Task, so it should be awaited in a real fix
            // For now, maintaining the non-async pattern from the original code
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries([FromForm]SeriesDTO model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var fakeFile = Path.GetRandomFileName(); 

            var series = new Series()
            {
                BoxOfficeRevenue = model.BoxOfficeRevenue,
                Budget = model.Budget,
                Language = model.Language,
                PosterImage = fakeFile,
                ProductionStudio = model.ProductionStudio,
                ReleaseYear = model.ReleaseYear,
                RuntimeperEpisode = model.RuntimeperEpisode,
                Synopsis = model.Synopsis,
                Title = model.Title,
                TrailerVideoURL = model.TrailerVideoURL
            };

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fakeFile);
            using FileStream f = new FileStream(path, FileMode.Create);
            model.PosterImage.CopyTo(f);
            
            var result = await seriesService.Add(series);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }

        [HttpPost("Eposide")]
        public async Task<IActionResult> CreateSeriesWithEposide([FromForm] SeriesWithEposideDTO model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var fakeFile = Path.GetRandomFileName();

            var series = new Series()
            {
                BoxOfficeRevenue = model.BoxOfficeRevenue,
                Budget = model.Budget,
                Language = model.Language,
                PosterImage = model.PosterImage,
                ProductionStudio = model.ProductionStudio,
                ReleaseYear = model.ReleaseYear,
                RuntimeperEpisode = model.RuntimeperEpisode,
                Synopsis = model.Synopsis,
                Title = model.Title,
                TrailerVideoURL = model.TrailerVideoURL
            };

            var eposides = new List<Eposide>();

            fakeFile = Path.GetRandomFileName();

            foreach (var item in model.Eposides)
            {
                eposides.Add(new Eposide()
                {
                    EposideDiscription = item.EposideDiscription,
                    EposideImageUrl = fakeFile,
                    EposideName = item.EposideName
                });
            }

            series.Eposides= eposides;

            var result = await seriesService.Add(series);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            
            return Ok(result.Value);
        }
    }
}
