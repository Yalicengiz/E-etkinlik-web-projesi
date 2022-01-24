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
    public class JoinsController : Controller
    {
        private IJoinService _JoinService;
        private IActivityService _activityService;

        public JoinsController(IJoinService JoinService,IActivityService activityService)
        {
            _JoinService = JoinService;
            _activityService = activityService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _JoinService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _JoinService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getjoinbyuserid")]
        public IActionResult GetJoinByUserId(int id)
        {
            var result = _JoinService.GetJoinUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getjoinbyuserandactivityid")]
        public IActionResult GetJoinByUserAndActivityId(int id,int actId)
        {
            var result = _JoinService.GetJoinUserAndActivityId(id, actId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(Join Join)
        {
            Join.JoinDate=DateTime.Now;
            Join.ReturnDate = 0;
            var result = _JoinService.Add(Join);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Join Join)
        {

            var result = _JoinService.Delete(Join);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("joinDelete")]
        public IActionResult DeleteJoin(int id)
        {

            var result = _JoinService.DeleteJoin(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Join Join)
        {
            var result = _JoinService.Update(Join);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
