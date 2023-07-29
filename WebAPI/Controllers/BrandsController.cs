using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase,IEntityControllerBase<Brand>
    {

        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpPost("delete")]
        public IActionResult Delete(Brand entity)
        {
            var result =_brandService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("insert")]
        public IActionResult Insert(Brand entity)
        {
            var result = _brandService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(Brand entity)
        {
            var result = _brandService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}
