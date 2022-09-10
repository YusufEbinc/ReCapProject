using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            
            if (user.FirstName ==null)
            {
                return new ErrorResult("işlem hatalı");
            }

            _userDal.Add(user);
            return new SuccesResult( "işlem başarılı");
        }

        public IResult Delete(User user)
        {
            if (user.FirstName == null)
            {
                return new ErrorResult("işlem hatalı");
            }

            _userDal.Delete(user);
            return new SuccesResult("işlem başarılı");
        }
        public IResult Update(User user)
        {

          
            if (user.FirstName == null)
            {
                return new ErrorResult("işlem hatalı");
            }

            _userDal.Update(user);
            return new SuccesResult("işlem başarılı");
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccesDataResult<User>(_userDal.Get(u=>u.UserId==id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }

       
    }
}
