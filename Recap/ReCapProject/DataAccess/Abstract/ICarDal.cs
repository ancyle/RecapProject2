using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        Task<IEnumerable<CarDetailDto>> GetAllCarDetailsDtosAsync(Expression<Func<CarDetailDto, bool>>? filter = null);
        Task<CarDetailDto?> GetCarDetailsDtoAsync(Expression<Func<CarDetailDto, bool>> filter);
    }
}
