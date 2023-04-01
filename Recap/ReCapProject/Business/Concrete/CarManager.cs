using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carDal.AddAsync(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carDal.DeleteAsync(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<IEnumerable<Car>> GetAllCars()
        {
            return new SuccessDataResult<IEnumerable<Car>>(_carDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            var result = _carDal.GetAsync(c => c.CarId == carId).Result;
            return result == null
                ? new ErrorDataResult<Car>(Messages.NotFound)
                : new SuccessDataResult<Car>(result, Messages.Found);
        }

        public IDataResult<IEnumerable<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<IEnumerable<Car>>
                (_carDal.GetAllAsync(c => c.BrandId == brandId).Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<IEnumerable<Car>>
                    (_carDal.GetAllAsync(c => c.ColorId == colorId).Result, Messages.Listed);
        }

        public IResult Update(Car car)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _carDal.UpdateAsync(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtos()
        {
            return new SuccessDataResult<IEnumerable<CarDetailDto>>
                (_carDal.GetAllCarDetailsDtosAsync().Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtosByColor(string colorName)
        {
            return new SuccessDataResult<IEnumerable<CarDetailDto>>
                (_carDal.GetAllCarDetailsDtosAsync(x => x.ColorName == colorName).Result, Messages.Listed);
        }

        public IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtosByBrand(string brandName)
        {
            return new SuccessDataResult<IEnumerable<CarDetailDto>>
                (_carDal.GetAllCarDetailsDtosAsync(x => x.BrandName == brandName).Result, Messages.Listed);
        }

        public IDataResult<CarDetailDto> GetCarDetailDtoById(int carId)
        {
            var result = _carDal.GetCarDetailsDtoAsync(x => x.CarId == carId).Result;
            return result == null
                ? new ErrorDataResult<CarDetailDto>(Messages.NotFound)
                : new SuccessDataResult<CarDetailDto>(result, Messages.Found);
        }

        //private IResult CheckCarName(string? name)
        //{
        //    if (name != null && name.Length < 2) return new ErrorResult("Description must be longer.");
        //    return new SuccessResult();
        //}

        //private IResult CheckDailyPrice(decimal price)
        //{
        //    if (price <= 0) return new ErrorResult("Price must be greater than 0.");
        //    return new SuccessResult();
        //}
    }
}
