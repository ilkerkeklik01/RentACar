//using Business.Abstract;
//using Core.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    //Maybe Later
//    public class EntityControllerBase<T> : ControllerBase,IEntityControllerBase<T> where T : class,IEntity, new()
//    {

//        IEntityService<T> _entityService;

//        public EntityControllerBase(IEntityService<T> entityService)
//        {
//            _entityService = entityService;
//        }

//        public IActionResult Delete(T entity)
//        {
//            var result =_entityService.Delete(entity);

//            if(result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);

//        }

//        public IActionResult GetAll()
//        {
//            var result = _entityService.GetAll();

//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        public IActionResult GetById(int id)
//        {
//            var result = _entityService.GetById(id);

//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        public IActionResult Insert(T entity)
//        {
//            var result = _entityService.Insert(entity);

//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        public IActionResult Update(T entity)
//        {
//            var result = _entityService.Update(entity);

//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
//    }
//}
