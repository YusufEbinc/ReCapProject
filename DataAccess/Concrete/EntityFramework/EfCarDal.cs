using Core.DataAccess;
using Core.DataAccess.EntityFramawork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Context context = new Context())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join r in context.Colors on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName
                             };
                return result.ToList();
            };

        }

    }
}

