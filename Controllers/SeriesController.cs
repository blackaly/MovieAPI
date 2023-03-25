using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.Model.Domains;
using MovieAPI.Model.DTOs;
using MovieAPI.Services.Interfaces;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;

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
            var obj = await seriesService.GetAll();
            
            if(obj != null)
            {

                foreach(var o in obj)
                {
                    if (o.PosterImage.IsNullOrEmpty()) continue;
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", o.PosterImage);
                    MemoryStream s = new MemoryStream();
                    using FileStream f = new FileStream(path, FileMode.Open);
                    f.CopyTo(s);
                    s.Position = 0;
                    o.PosterImage = Convert.ToBase64String(s.ToArray());
                    Response.SendFileAsync(s.ToArray());
                }

                return Ok(obj);
            }

            return Ok(obj);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSeriesBy(int id)
        {
            var obj = await seriesService.GetBy(id);
            return Ok(obj);
        }

        [HttpGet("name")]
        public IActionResult GetSeriesBy(string title)
        {
            var obj = seriesService.GetBy(title);
            return Ok(obj);
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
            await seriesService.Add(series);

            return Ok(series);
        }

        [HttpPost("Eposide")]
        public async Task<IActionResult> CreateSeriesWithEposide(SeriesWithEposideDTO model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

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

            foreach(var item in model.Eposides)
            {
                eposides.Add(new Eposide()
                {
                    EposideDiscription = item.EposideDiscription,
                    EposideImageUrl = item.EposideImageUrl,
                    EposideName = item.EposideName
                });
            }

            series.Eposides= eposides;

            await seriesService.Add(series);
            return Ok();
        }

    }
}
