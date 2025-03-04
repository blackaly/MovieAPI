﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.Model.Domains;
using MovieAPI.Model.DTOs;
using MovieAPI.Services.Implementation;
using MovieAPI.Services.Interfaces;
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
            var obj = await _eposideService.GetAll();

            if (obj.Count() <= 0) return NoContent();

            return Ok(obj);
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

                if (!string.IsNullOrEmpty(o.EposideImageUrl.FileName))
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fakeFile);
                    using FileStream f = new FileStream(path, FileMode.Create);
                    o.EposideImageUrl.CopyTo(f);
                }
            }

            await _eposideService.Add(id, ep);

            return Ok();
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
               

                if (!string.IsNullOrEmpty(eposides.EposideImageUrl.FileName))
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fakeFile);
                    using FileStream f = new FileStream(path, FileMode.Create);
                eposides.EposideImageUrl.CopyTo(f);
                }
            var output = await _eposideService.Add(id, ep);
            if(output != null)
                return Ok(output);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditEposide([FromQuery]int id, [FromForm]EposideDTO eposide)
        {
            try
            {
                var obj = await _eposideService.GetBy(id);
                if (!ModelState.IsValid) return BadRequest("There is no eposide with this id");

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


                var output = await _eposideService.EditEposide(obj);

                return Ok(output);
            }catch(Exception error)
            {
                return BadRequest(error.Message);
            }

            
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetEposideyId(int id)
        {
            var obj = await _eposideService.GetBy(id);

            if (obj == null) return NoContent();

            return Ok(obj);
        }

        [HttpGet("ByName")]
        public  IActionResult GetEposideyName(string name)
        {
            var obj =  _eposideService.GetBy(name);
            if (obj.Count() <= 0) return NoContent();
            return Ok(obj);
        }

        [HttpGet("BySeriesId")]
        public IActionResult GetEposideBySeriesId(int id)
        {
            var obj = _eposideService.GetEposideWithSeriesiD(id);
            if(obj.Count() <= 0) return NoContent();
            return Ok(obj);
        }


        [HttpGet("BySeriesName")]
        public IActionResult GetEposideBySeriesName(string name)
        {
            var obj = _eposideService.GetEposideWithSeriesName(name);
            if (obj.Count() <= 0) return NoContent();
            return Ok(obj);
        }
    }
}
