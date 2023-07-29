using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase, IEntityControllerBase<Color>
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("delete")]

        public IActionResult Delete(Color entity)
        {
            var result = _colorService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("insert")]

        public IActionResult Insert(Color entity)
        {
            var result = _colorService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Color entity)
        {
            var result = _colorService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
