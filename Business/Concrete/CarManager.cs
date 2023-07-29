using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Connecting data base and business
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //warning  kosullarimi business tarafina yaziyorum database ile karistirmiyorum
        public IResult Insert(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult("Car inserted!");
            }
            return new ErrorResult("Invalid car element!");
            

        }

        public IDataResult<List<Car>> GetAll()
        {   

            if(DateTime.Now.Hour ==1) {
                return new ErrorDataResult<List<Car>>( "System is in maintenance!");

            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Cars listed!");


        }

        public IDataResult<Car> GetById(int id) 
        {

            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),"Car CarId:"+id+" provided!");

        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(), "Car details provided!");

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), "Car BrandId:" + brandId + " probided!");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), "Car ColorId:"+colorId+" provided!");


        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult("Car updated!");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Car deleted");
        }
    }
}
