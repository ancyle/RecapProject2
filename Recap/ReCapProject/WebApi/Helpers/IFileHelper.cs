namespace WebApi.Helpers
{
    public interface IFileHelper
    {
        Task<Core.Utilities.Results.IResult> UploadAsync(IFormFile formFile);
        Task<string?> UpdateAsync(IFormFile file,string original);
        Task DeleteAsync(string path);

    }
}
