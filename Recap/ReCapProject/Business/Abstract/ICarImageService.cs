using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        IDataResult<IEnumerable<CarImage>> GetAll();
        IDataResult<IEnumerable<CarImage>> GetAllByCar(int carId);
        IDataResult<CarImage> GetById(int carImageId);
    }
}
