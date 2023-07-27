using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(efCarDal);

            Car car1 = new Car() { CarId=14,Description="sanane",DailyPrice=210};
            //efCarDal.Add(car1);
            //efCarDal.Update(car1);
            efCarDal.Delete(car1);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            //Console.WriteLine(carManager.GetById(14).Description);


        }
    }
}