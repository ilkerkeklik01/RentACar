using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this._colorDal = colorDal;
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);

        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorID == id);
        }

        public void Insert(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }
    }
}
