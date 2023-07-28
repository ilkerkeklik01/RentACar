using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public List<CarDetailDTO> GetCarDetails()
        {

            using (MyReCapProjectDataBaseContext context = new MyReCapProjectDataBaseContext())
            {
                //Warning
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorID
                             select new CarDetailDTO()
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
                             
            }


        }



    }
}
