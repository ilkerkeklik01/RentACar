using Business.Abstract;
using Core.Utilities.Results;
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
        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult("Color deleted!");

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), "Colors Listed");
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), "Color ColorID:" + id + " is provided!");
        }

        public IResult Insert(Color entity)
        {
            _colorDal.Add(entity);

            return new SuccessResult("Color inserted!");
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult("Color updated!");

        }
        
    }
}
