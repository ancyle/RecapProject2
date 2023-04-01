using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetCarById(int carId);
        IDataResult<IEnumerable<Car>> GetCarsByBrandId(int brandId);
        IDataResult<IEnumerable<Car>> GetCarsByColorId(int colorId);
        IDataResult<IEnumerable<Car>> GetAllCars();
        IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtos();
        IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtosByColor(string colorName);
        IDataResult<IEnumerable<CarDetailDto>> GetAllCarsDtosByBrand(string brandName);
        IDataResult<CarDetailDto> GetCarDetailDtoById(int carId);
    }
}
