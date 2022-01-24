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
    public class PriceTypeController : Controller
    {
        private IPriceType _PriceTypeService;

        public PriceTypeController(IPriceType PriceTypeService)
        {
            _PriceTypeService = PriceTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _PriceTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _PriceTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(PriceType IsFree)
        {
            var result = _PriceTypeService.Add(IsFree);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(PriceType IsFree)
        {
            var result = _PriceTypeService.Delete(IsFree);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PriceType IsFree)
        {
            var result = _PriceTypeService.Update(IsFree);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
