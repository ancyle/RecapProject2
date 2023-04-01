using Core.Utilities.Results;
using System.Data;

namespace WebApi.Helpers
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _webEnvironment;
        public FileHelper(IWebHostEnvironment webEnvironment)
        {
            _webEnvironment = webEnvironment;
        }
        public async Task<Core.Utilities.Results.IResult> UploadAsync(IFormFile formFile)
        {
            var guidName = Guid.NewGuid().ToString();
            var directoryPath = Path.Combine(_webEnvironment.ContentRootPath, "UploadedImages", "Cars");
            var filePath = Path.Combine(directoryPath);
            var extension = Path.GetExtension(formFile.FileName);
           
            if (formFile == null) throw new NoNullAllowedException();
            else
            {
                await using var stream = new FileStream(Path.Combine(filePath, (guidName + extension)), FileMode.Create);
                await formFile.CopyToAsync(stream);

                return new SuccessResult("UploadedImages/Cars/"+ (guidName + extension));
            }
        }
        public async Task<string?> UpdateAsync(IFormFile file, string original)
        {
            if (File.Exists(original)) File.Delete(original);
            var result = await UploadAsync(file);
            return result.Message.Length > 0 ? result.Message : null;
        }
        public async Task DeleteAsync(string path)
        {
            if (path.Length > 0 && File.Exists(path))
            {
                await Task.Run(() => { File.Delete(path); });
            }
        }
    }
}
