using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _customerDal.AddAsync(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _customerDal.DeleteAsync(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<IEnumerable<Customer>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Customer>>
                (_customerDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<Customer>> GetAllByUser(int userId)
        {
            return new SuccessDataResult<IEnumerable<Customer>>
                      (_customerDal.GetAllAsync(c => c.UserId == userId).Result, Messages.Listed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var result = _customerDal.GetAsync(c => c.Id == customerId).Result;
            return result == null
                ? new ErrorDataResult<Customer>(Messages.NotFound)
                : new SuccessDataResult<Customer>(result, Messages.Found);
        }

        public IResult Update(Customer customer)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _customerDal.UpdateAsync(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
