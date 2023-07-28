using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService:IEntityService<Car>
    {
        List<Car> GetAll();
        Car GetById(int id);
        
        List<Car> GetCarsByBrandId(int brandId);

        List<Car> GetCarsByColorId(int colorId);
        
        void Insert(Car car);

        List<CarDetailDTO> GetCarDetails();

        void Update(Car car);
        void Delete(Car car);

    }
}
