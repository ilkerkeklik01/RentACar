using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{                                                                                   //warning
    public class EfCarDal:EfEntityRepositoryBase<Car,MyReCapProjectDataBaseContext>,ICarDal
    {
        //warning
        public void Add(Car car)
        {
            Console.WriteLine("Yenisi calisti");
            using (MyReCapProjectDataBaseContext context = new MyReCapProjectDataBaseContext())
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    var addedEntity = context.Entry(car);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                
            }
        }
    }
}
