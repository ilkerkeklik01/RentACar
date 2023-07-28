using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {


        List<CarDetailDTO> GetCarDetails();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAll();
        //Car GetById(int id);

    }
}
