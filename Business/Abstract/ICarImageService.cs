using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService 
    {

        IResult Insert(CarImage entity,IFormFile formFile);
        IResult Update(CarImage entity,IFormFile formFile);
        IResult Delete(CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IDataResult<List<string>> GetCarImagesURLCarId(int carId);
        



    }
}