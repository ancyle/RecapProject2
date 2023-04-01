using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<IEnumerable<Rental>> GetAll();
        IDataResult<IEnumerable<Rental>> GetAllByCarId(int carId);
        IDataResult<IEnumerable<RentalDetailDto>> GetAllRentalDetailsDtos();
        IDataResult<Rental> Get(int rentalId);
    }
}
