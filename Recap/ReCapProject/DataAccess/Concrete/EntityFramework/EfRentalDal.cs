using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public async Task<IEnumerable<RentalDetailDto>> GetAllRentalDetailsDtosAsync()
        {
            await using var context = new ReCapContext();
            var result = from r in context.Rentals
                         join c in context.Cars
                         on r.CarId equals c.CarId
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         join u in context.Users
                         on r.CustomerId equals u.UserId
                         select new RentalDetailDto
                         {
                             BrandName = b.BrandName,
                             CustomerName = u.FirstName + u.LastName,
                             RentalId = r.RentalId,
                             RentDate = r.RentDate,
                             ReturnDate = r.ReturnDate
                         };
            return await result.ToListAsync();
        }
    }
}
