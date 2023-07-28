using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this._brandDal = brandDal;
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);

        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }

        public void Insert(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
