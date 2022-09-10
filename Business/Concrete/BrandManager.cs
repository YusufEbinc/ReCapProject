using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //deneme_ eklendi
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _brandDal.Add(brand);
            return new SuccesResult("işlem başarılı");
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandId==0)
            {
                return new ErrorResult("brandId sıfırdan farklı olmalı");
            }
            _brandDal.Delete(brand);

            return new SuccesResult( "veriler silindi");
        }
        public IResult Update(Brand brand)
        {
          
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _brandDal.Update(brand);

            return new SuccesResult( "veriler Güncellendi");
        }
        public IDataResult<Brand> Get(int id)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b=>b.BrandId==id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll());
        }


    }
}
