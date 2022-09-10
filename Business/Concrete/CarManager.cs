using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _carDal.Add(car);
            return new SuccesResult("işlem başarılı");
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccesResult("işlem başarılı");
           
        }
        public IResult Update(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _carDal.Update(car);
            return new SuccesResult("işlem başarılı");
         
        }


        public IDataResult<Car> Get(int id)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),"işlem başarılı");
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
