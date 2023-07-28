using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        

        public InMemoryCarDal()
        {
            _cars = new List<Car>() {

            new Car {CarId=1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=749,Description="Toyata Vits" },
                new Car {CarId=2,BrandId=1,ColorId=2,ModelYear=2018,DailyPrice=749,Description="Toyata Coralla" },
                new Car {CarId=3,BrandId=1,ColorId=5,ModelYear=2014,DailyPrice=850,Description="Toyata Auris" },
                new Car {CarId=4,BrandId=2,ColorId=4,ModelYear=2022,DailyPrice=1010,Description="Mercedes E200" },
                new Car {CarId=5,BrandId=2,ColorId=6,ModelYear=2021,DailyPrice=1000,Description="Mercedes E150" },
                new Car {CarId=6,BrandId=3,ColorId=3,ModelYear=2023,DailyPrice=1500,Description="BMW M Serisi M5" },
                new Car {CarId=7,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=1300,Description="BMW M Serisi M3" },
                new Car {CarId=8,BrandId=3,ColorId=2,ModelYear=2022,DailyPrice=1400,Description="BMW X4" },
                new Car {CarId=9,BrandId=4,ColorId=1,ModelYear=1999,DailyPrice=450,Description="Fiat Egea 1.3 Multijet Easy" },
                new Car {CarId=10,BrandId=4,ColorId=5,ModelYear=2001,DailyPrice=350,Description="Fiat Egea 1.4 Easy" },
                new Car {CarId=11,BrandId=4,ColorId=5,ModelYear=2004,DailyPrice=950,Description="Fiat Egea 1.6 Multijet Lounge DCT" },
                new Car {CarId=12,BrandId=5,ColorId=6,ModelYear=2009,DailyPrice=250,Description="Suzuki Swift 1.2 GL" },
                new Car {CarId=13,BrandId=5,ColorId=4,ModelYear=2015,DailyPrice=500,Description="Suzuki Swift 1.6 Sport" }


            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var deletedCar = _cars.SingleOrDefault(c=> c.CarId==entity.CarId);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            //warning
            Func<Car,bool> compiledFilter = filter.Compile();
            return _cars.SingleOrDefault(compiledFilter);

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            Func<Car, bool> compiledFilter = filter.Compile();
            return _cars.Where(compiledFilter).ToList();


        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            var updatedCar = _cars.SingleOrDefault(c=>entity.CarId==c.CarId);
            updatedCar.DailyPrice=entity.DailyPrice;
            updatedCar.Description=entity.Description;
            updatedCar.ModelYear=entity.ModelYear;
            updatedCar.BrandId=entity.BrandId;
            updatedCar.ColorId=entity.ColorId;
        }

        //public void Insert(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car deletedCar = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
        //    _cars.Remove(deletedCar);
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Car GetById(int id)
        //{
        //    Car car = _cars.SingleOrDefault(c => c.CarId == id);
        //    return car;
        //}

        //public void Update(Car car)
        //{
        //    Car updatedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        //    updatedCar.DailyPrice=car.DailyPrice;
        //    updatedCar.Description=car.Description;
        //    updatedCar.ModelYear=car.ModelYear;
        //    updatedCar.BrandId=car.BrandId;
        //    updatedCar.ColorId=car.ColorId;

        //}

        //public List<CarDetailDTO> GetCarDetails()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Car entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
