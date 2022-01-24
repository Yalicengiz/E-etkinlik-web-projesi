using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : Controller
    {
        private IActivityTypeService _ActivityTypeService;

        public ActivityTypesController(IActivityTypeService ActivityTypeService)
        {
            _ActivityTypeService = ActivityTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ActivityTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ActivityTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(ActivityType ActivityType)
        {
            var result = _ActivityTypeService.Add(ActivityType);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ActivityType ActivityType)
        {
            var result = _ActivityTypeService.Delete(ActivityType);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ActivityType ActivityType)
        {
            var result = _ActivityTypeService.Update(ActivityType);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
