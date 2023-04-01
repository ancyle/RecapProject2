using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rendalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rendalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.GetResult(CheckIfCarRented(rental));
            if (result != null) return result;
            _rendalDal.AddAsync(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _rendalDal.DeleteAsync(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            var result = _rendalDal.GetAsync(r => r.RentalId == rentalId).Result;
            return result == null
                ? new ErrorDataResult<Rental>(Messages.NotFound)
                : new SuccessDataResult<Rental>(result, Messages.Found);
        }

        public IDataResult<IEnumerable<Rental>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Rental>>(_rendalDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<IEnumerable<Rental>>
                (_rendalDal.GetAllAsync(r => r.CarId == carId).Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<RentalDetailDto>> GetAllRentalDetailsDtos()
        {
            return new SuccessDataResult<IEnumerable<RentalDetailDto>>
                (_rendalDal.GetAllRentalDetailsDtosAsync().Result, Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _rendalDal.UpdateAsync(rental);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfCarRented(Rental rental)
        {
            var cars = this.GetAllByCarId(rental.CarId).Data;
            var result = cars.SingleOrDefault(x => x.ReturnDate ==null);
            if (result == null) return new SuccessResult();
            return new ErrorResult();
        }
    }
}
