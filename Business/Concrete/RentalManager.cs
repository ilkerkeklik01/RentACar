using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal) { 
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult("Rental deleted!");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),"Rentals listed!");

        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id),"Rental RentalId:"+id+" provided!");
        }

        //Renting a car
        public IResult Insert(Rental entity)
        {



            var result = IsSuitableToRent(entity);

            if (result.Success) {
            _rentalDal.Add(entity);
                return new SuccessResult("Rental inserted! -- "+result.Message);
            }
            return new ErrorResult("Rental is not inserted! -- "+result.Message);
            
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult("Rental updated");
        }

        public IResult IsSuitableToRent(Rental entity)
        {
            bool isSuitable = true;

            List<Rental> allRentals= this.GetAll().Data;

            foreach (Rental item in allRentals.Where(r=>r.CarId==entity.CarId))
            {
                if (item.ReturnDate==null)
                {
                    isSuitable = false;
                }
            }


            return (isSuitable) ? new SuccessResult("Rental is suitable!") :
                new ErrorResult( "Rental is not suitable!");

        }

        
    }
}
