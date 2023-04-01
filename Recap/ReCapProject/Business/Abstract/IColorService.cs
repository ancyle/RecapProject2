using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color> GetColorById(int colorId);
        IDataResult<IEnumerable<Color>> GetAllColors();
    }
}
