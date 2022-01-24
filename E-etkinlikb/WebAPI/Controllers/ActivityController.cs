using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitysController : Controller
    {

        private IActivityService _ActivityService;

        public ActivitysController(IActivityService ActivityService)
        {
            _ActivityService = ActivityService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ActivityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallactivity")]
        public IActionResult GetAllActivity()
        {

            Thread.Sleep(2000);
            var result = _ActivityService.GetActivityDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ActivityService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Activity Activity)
        {
            var result = _ActivityService.Add(Activity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getactivitydetailsbyactivitytypeid")]
        public IActionResult GetActivityDetailsByActivityId(int id)
        {
            var result = _ActivityService.GetActivitysByActivityTypeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getactivitydetailsbypricetypeid")]
        public IActionResult GetActivityDetailsByPriceTypeId(int id)
        {
            var result = _ActivityService.GetActivitysByIsFreeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpDelete("delete")]
        public IActionResult Delete(Activity Activity)
        {
            var result = _ActivityService.Delete(Activity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Activity Activity)
        {
            var result = _ActivityService.Update(Activity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
