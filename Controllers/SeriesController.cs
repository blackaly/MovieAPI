using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model.Domains;
using MovieAPI.Model.DTOs;
using MovieAPI.Services.Interfaces;
using System.Diagnostics.Metrics;
using System.Runtime.Remoting;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            this.seriesService = seriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            var obj = await seriesService.GetAll();
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
        public async Task<IActionResult> CreateSeries(SeriesDTO model)
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
