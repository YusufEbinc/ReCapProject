using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : ICarDal
    {
            
        List<Car> _carList;

        public InMemoryDal()
        {
            _carList = new List<Car> {

                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 1998, DailyPrice = 50000, Description = "passat acıklama" },
                new Car { Id = 2, BrandId = 1, ColorId = 1, ModelYear = 2016, DailyPrice = 63000, Description = "passat acıklama" },
                new Car { Id = 3, BrandId = 1, ColorId = 8, ModelYear = 1999, DailyPrice = 100000, Description = "passat acıklama" },
                new Car { Id = 4, BrandId = 2, ColorId = 5, ModelYear = 2015, DailyPrice = 95000, Description = "jetta acıklama" },
                new Car { Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2022, DailyPrice = 25360, Description = "jetta acıklama" },
                new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2005, DailyPrice = 75000, Description = "transpoter acıklama" },
                     
            };
            }
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _carList.SingleOrDefault(c => c.Id == car.Id);
            _carList.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _carList.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carList.SingleOrDefault(c => c.Id == car.Id); 
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
          

        }
    }
}
