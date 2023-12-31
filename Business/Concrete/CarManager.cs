﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        //Do not implement business and other CrossCuttingConcerns together. Use AOP instead


        [ValidationAspect(typeof(CarValidator))] //Attribute 
        public IResult Insert(Car car)
        {
            //validation,log,cacheremove,performance,transaction,authorization processes is moved outside the method body
            //with AOP
            _carDal.Add(car);
            return new SuccessResult("Car inserted!");
        }   

        public IDataResult<List<Car>> GetAll()
        {   

            if(DateTime.Now.Hour ==7) {
                return new ErrorDataResult<List<Car>>("System is in maintenance!");

            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Cars listed!");


        }

        public IDataResult<Car> GetById(int id) 
        {

            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),"Car CarId:"+id+" is provided!");

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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            BusinessRules.Run();

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
