using Business.Abstract;
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

        public IResult Insert(Rental entity)
        {
            return new SuccessResult("Rental inserted!");
        }

        public IResult Update(Rental entity)
        {
            return new SuccessResult("Rental updated");
        }
    }
}
