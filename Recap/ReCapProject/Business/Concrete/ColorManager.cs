using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _colorDal.AddAsync(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _colorDal.DeleteAsync(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<IEnumerable<Color>> GetAllColors()
        {
            return new SuccessDataResult<IEnumerable<Color>>(_colorDal.GetAllAsync().Result, Messages.Listed);
        }

        public IDataResult<Color> GetColorById(int colorId)
        {
            var result = _colorDal.GetAsync(b => b.ColorId == colorId).Result;
            return result == null
                ? new ErrorDataResult<Color>(Messages.NotFound)
                : new SuccessDataResult<Color>(result, Messages.Found);
        }

        public IResult Update(Color color)
        {
            var result = BusinessRules.GetResult();
            if (result != null) return result;
            _colorDal.UpdateAsync(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
