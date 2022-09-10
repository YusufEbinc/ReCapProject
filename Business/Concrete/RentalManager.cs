using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            //if (rental.ReturnDate==null)
            //{
            //    return new ErrorResult("araba teslim edilmemiş");
            //}
            _rentalDal.Add(rental);
            return new SuccesResult("işlem başarılı bir şekilde gerçekleşmiştir");
        }

        public IResult Delete(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult("araba teslim edilmemiş");
            }
            _rentalDal.Delete(rental);
            return new SuccesResult("işlem başarılı bir şekilde gerçekleşmiştir");
        }
        public IResult Update(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult("araba teslim edilmemiş");
            }
            _rentalDal.Update(rental);
            return new SuccesResult("işlem başarılı bir şekilde gerçekleşmiştir");
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        
    }
}
