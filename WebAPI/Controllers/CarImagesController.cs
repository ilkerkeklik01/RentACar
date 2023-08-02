using Business.Abstract;
using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpPost("delete")]
        public IActionResult Delete(CarImage entity)
        {

            var result = _carImageService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }



        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpPost("insert")]
        public IActionResult Insert([FromForm] CarImage entity, [FromForm] IFormFile file)
        {

            var result = _carImageService.Insert(entity,file);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage entity, [FromForm]IFormFile file)
        {
            var result = _carImageService.Update(entity,file);

            if(result.Success)
            {
                return Ok(result);  
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesByCarId(int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcarimagesurlbycarid")]
        public IActionResult GetCarImagesURLByCarId(int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}
