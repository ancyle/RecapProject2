using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _brandDal.AddAsync(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _brandDal.DeleteAsync(brand);
            return new SuccessResult(Messages.Deleted);
        }


        public IDataResult<IEnumerable<Brand>> GetAllBrands()
        {
            return new SuccessDataResult<IEnumerable<Brand>>(_brandDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            var result = _brandDal.GetAsync(b => b.BrandId == brandId).Result;
            return result == null
                ? new ErrorDataResult<Brand>(Messages.NotFound)
                : new SuccessDataResult<Brand>(result, Messages.Found);
        }

        public IResult Update(Brand brand)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _brandDal.UpdateAsync(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
