using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _userDal.AddAsync(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _userDal.DeleteAsync(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<User>>(_userDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.GetAsync(u => u.UserId == userId).Result;
            return result == null
                ? new ErrorDataResult<User>(Messages.NotFound)
                : new SuccessDataResult<User>(result, Messages.Found);
        }

        public IResult Update(User user)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _userDal.UpdateAsync(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
