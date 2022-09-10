using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _customerDal.Add(customer);

            return new SuccesResult("işlem başarılı");
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _customerDal.Delete(customer);

            return new SuccesResult("işlem başarılı");
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult("işlem hatalı");
            }
            _customerDal.Update(customer);

            return new SuccesResult("işlem başarılı");
        }


        public IDataResult<Customer> Get(int id)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(c=>c.UserId==id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll());
        }

     
    }
}
