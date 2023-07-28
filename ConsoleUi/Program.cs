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
            CarTest();
            ColorTest();
            BrandTest();
            


            //Console.WriteLine(carManager.GetById(14).Description);


        }

        private static void BrandTest()
        {
            Console.WriteLine("\nBrands\n\n");

            EfBrandDal efBrand = new EfBrandDal();
            BrandManager brandManager = new BrandManager(efBrand);
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void ColorTest()
        {
            Console.WriteLine("\nColors\n\n");

            EfColorDal efColor = new EfColorDal();
            ColorManager colorManager = new ColorManager(efColor);
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("\nCars\n\n");
            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(efCarDal);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            
            Console.WriteLine("\nCar Details\n\n");
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item);
            }

        }
    }
}