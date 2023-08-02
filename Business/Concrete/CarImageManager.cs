using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _imageDal = carImageDal;
        }

        public IResult Delete(CarImage entity)
        {

            if(!string.IsNullOrEmpty(entity.ImagePath))
            {
                if(File.Exists(entity.ImagePath))
                {
                    File.Delete(entity.ImagePath);
                }


            }

            _imageDal.Delete(entity);
            return new SuccessResult("CarImage deleted!");
            
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(),"CarImages listed!");

        }

        public IDataResult<CarImage> GetById(int id)
        {
            var ent = _imageDal.Get(ci => ci.CarImageId == id);

            if(ent == null)
            {
                return new ErrorDataResult<CarImage>();
            }

            return new SuccessDataResult<CarImage>(_imageDal.Get(ci => ci.CarImageId == id)
                ,"CarImage Id: "+id+" is provided!");
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var res = _imageDal.GetAll(ci => ci.CarId == carId);

            return new SuccessDataResult<List<CarImage>>(res,"CarImages CarId: "+carId+" provided!");    
        }

        public IDataResult<List<string>> GetCarImagesURLCarId(int carId)
        {
            var images= GetCarImagesByCarId(carId).Data;
            var res = images.Select(i=> i.ImagePath).ToList();

            return new SuccessDataResult<List<string>>(res,"List of image paths of Car CarId:"+carId+" provided!");
        }




        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(CarImage entity,IFormFile file)
        {
            var res = BusinessRules.Run(IsNumOfImageOverflowedPerCar(entity.CarId));

            if(res !=  null)
            {
                return res;
            }


            if (file != null && file.Length>0)
            {
                var guidFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var imagePath = Path.Combine(Environment.CurrentDirectory,
                    Messages.PathToCarImages,
                    guidFileName
                    );

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                entity.ImagePath = imagePath;
            }
            else
            {
                return new ErrorResult("File cannot be inserted! File is invalid");
            }
            entity.Date = DateTime.Now;
            _imageDal.Add(entity);
            return new SuccessResult("CarImage inserted!");
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage entity, IFormFile file)
        {

            var ruleres =BusinessRules.Run(IsNumOfImageOverflowedPerCar(entity.CarId));
            
            if (ruleres != null)
            {
                return ruleres;
            }



            var res =_imageDal.GetAll().SingleOrDefault(i=> i.CarImageId==entity.CarImageId)!=null;

            if (!res)
            {
                return new ErrorResult("File cannot be updated! Entity is not exist");

            }
            if (file!=null && file.Length > 0)
            {
                var guidFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var newImagePath = Path.Combine(Environment.CurrentDirectory,
                    Messages.PathToCarImages,
                    guidFileName);

                using (var stream = new FileStream(newImagePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                DeleteImageFileFromImagePathIfExists(entity.ImagePath);

                entity.ImagePath = newImagePath;


            }
            else
            {
                return new ErrorResult("File cannot be updated! File is invalid");

            }
            entity.Date= DateTime.Now;
            _imageDal.Update(entity);
            return new SuccessResult("CarImage updated!");

        }


       private bool DeleteImageFileFromImagePathIfExists(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }

            }
            return false;
        }

        private IResult IsNumOfImageOverflowedPerCar(int carId)
        {
            var res  = _imageDal.GetAll(i=>i.CarId == carId).Count;

            if (res < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult("# of image overflowed for carId: "+ carId);
        
        }
        
    }
}
