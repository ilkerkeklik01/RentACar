using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase,IEntityControllerBase<Customer>
    {


        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("delete")]

        public IActionResult Delete(Customer entity)
        {
            var result = _customerService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("insert")]

        public IActionResult Insert(Customer entity)
        {
            var result = _customerService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Customer entity)
        {
            var result = _customerService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
