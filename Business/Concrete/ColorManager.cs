using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult("işlem hatalı");
            }

            _colorDal.Add(color);
            return new SuccesResult("işlem başarılı");
          
        }

        public IResult Delete(Color color)
        {
            if (color.ColorId == 0)
            {
                return new ErrorResult("işlem hatalı");
            }
            _colorDal.Delete(color);

            return new SuccesResult("işlem başarılı");
        }
        public IResult Update(Color color)
        {
            if (color.ColorId == 0)
            {
                return new ErrorResult("işlem hatalı");
            }
            _colorDal.Update(color);

            return new SuccesResult("işlem başarılı");
        }

        public IDataResult<Color> Get(int id)
        {
           return new SuccesDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll());
        }

       
    }
}
