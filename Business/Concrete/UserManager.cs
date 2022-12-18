using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (user.FirstName.Length>2)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.CarListed);
        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
