using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase,IEntityControllerBase<User>
    {


        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("delete")]

        public IActionResult Delete(User entity)
        {
            var result = _userService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("insert")]
        public IActionResult Insert(User entity)
        {
            var result = _userService.Insert(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(User entity)
        {
            var result = _userService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
