using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<IEnumerable<Customer>> GetAll();
        IDataResult<IEnumerable<Customer>> GetAllByUser(int userId);
        IDataResult<Customer> GetById(int customerId);
    }
}
