using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(inMemoryCarDal);

            Car car1 = new Car()
            {
                CarId = 14,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 231,
                ModelYear = 2013,
                Description = "Yeni Ekledim"
            };
            inMemoryCarDal.Add(car1);

            Console.WriteLine(carManager.GetById(14).Description+"\n\n");

            Car car2 = new Car()
            {
                CarId = 14,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 231,
                ModelYear = 2013,
                Description = "ENNNN Yeni Ekledim"
            };

            inMemoryCarDal.Update(car2);    

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }





        }
    }
}