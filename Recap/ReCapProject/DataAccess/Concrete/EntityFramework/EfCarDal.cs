using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public async Task<IEnumerable<CarDetailDto>> GetAllCarDetailsDtosAsync(Expression<Func<CarDetailDto, bool>>? filter = null)
        {
            await using ReCapContext context = new();
            var result = from c in context.Cars
                         join co in context.Colors
                         on c.ColorId equals co.ColorId
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         select new CarDetailDto
                         {
                             BrandName = b.BrandName,
                             CarId = c.CarId,
                             ColorName = co.ColorName,
                             DailyPrice = c.Dailyprice,
                             Description = c.Description,
                             ModelYear = c.ModelYear
                         };
            return filter == null ? await result.ToListAsync() : await result.Where(filter).ToListAsync();
        }

        public async Task<CarDetailDto?> GetCarDetailsDtoAsync(Expression<Func<CarDetailDto, bool>> filter)
        {
            await using ReCapContext context = new();
            var result = from c in context.Cars
                         join co in context.Colors
                         on c.ColorId equals co.ColorId
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         select new CarDetailDto
                         {
                             BrandName = b.BrandName,
                             CarId = c.CarId,
                             ColorName = co.ColorName,
                             DailyPrice = c.Dailyprice,
                             Description = c.Description,
                             ModelYear = c.ModelYear
                         };
            return await result.SingleOrDefaultAsync(filter);
        }
    }
}
