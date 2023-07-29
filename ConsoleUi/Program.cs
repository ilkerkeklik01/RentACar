using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUi
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            ColorTest();
            BrandTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            Rental rental1 =new Rental()
            {
                RentalId = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2023, 07, 29),
                ReturnDate = null
            };

            rental1.ReturnDate = new DateTime(2023,07,31);

            var resultUpdate =rentalManager.Update(rental1);

            Console.WriteLine(resultUpdate.Message);
            
            Rental rental2 = new Rental()
            {
                RentalId = 2,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2023, 07, 29),
                ReturnDate = null
            };
            var resultInsert=rentalManager.Insert(rental2);
            Console.WriteLine(resultInsert.Message);


            //Console.WriteLine(carManager.GetById(14).Description);


        }

        private static void BrandTest()
        {
            Console.WriteLine("\nBrands\n\n");

            EfBrandDal efBrand = new EfBrandDal();
            BrandManager brandManager = new BrandManager(efBrand);
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void ColorTest()
        {
            Console.WriteLine("\nColors\n\n");

            EfColorDal efColor = new EfColorDal();
            ColorManager colorManager = new ColorManager(efColor);
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("\nCars\n\n");
            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(efCarDal);


            
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.Description);
            }

            
            Console.WriteLine("\nCar Details\n\n");
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item);
            }

        }
    }
}