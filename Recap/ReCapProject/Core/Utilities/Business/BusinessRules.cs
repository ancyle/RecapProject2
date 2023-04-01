using Core.Utilities.Results;
using System.Linq;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult? GetResult(params IResult[] results)
        {
            foreach (var result in results.Where(result => !result.Success))
            {
                return result;
            }

            return null;
        }
    }
}
