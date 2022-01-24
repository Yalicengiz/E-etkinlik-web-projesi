using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Core;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityImagesController : Controller
    {
        private IActivityImageService  _ActivityImageService;

        public ActivityImagesController(IActivityImageService ActivityImageService)
        {
            _ActivityImageService = ActivityImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ActivityImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ActivityImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] UserImage ActivityImage)
        {
            var result = _ActivityImageService.Add(file,ActivityImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var ActivityImage = _ActivityImageService.GetById(id).Data;
            var result = _ActivityImageService.Delete(new UserImage(){UserId = id});
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var image = _ActivityImageService.GetById(Id).Data;
            var result = _ActivityImageService.Update(file,new UserImage(){UserId = Id});
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
