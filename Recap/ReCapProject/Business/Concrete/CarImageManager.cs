using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carImageDal.AddAsync(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carImageDal.DeleteAsync(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<IEnumerable<CarImage>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<CarImage>>
                (_carImageDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<CarImage>> GetAllByCar(int carId)
        {
            return new SuccessDataResult<IEnumerable<CarImage>>
            (_carImageDal.GetAllAsync(c => c.CarId == carId).Result, Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var result = _carImageDal.GetAsync(c => c.CarImageId == carImageId).Result;
            return result == null
                ? new ErrorDataResult<CarImage>(Messages.NotFound)
                : new SuccessDataResult<CarImage>(result, Messages.Found);
        }

        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carImageDal.UpdateAsync(carImage);
            return new SuccessResult(Messages.Updated);
        }
    }
}
