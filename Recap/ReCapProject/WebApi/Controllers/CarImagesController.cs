using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        private readonly IFileHelper _fileHelper;
        public CarImagesController(ICarImageService carImageService, IFileHelper fileHelper)
        {
            _carImageService = carImageService;
            _fileHelper = fileHelper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbycar")]
        public IActionResult GetAllByCar(int carId)
        {
            var result = _carImageService.GetAllByCar(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]CarImage carImage, IFormFile formFile)
        {
            var imageResult = _fileHelper.UploadAsync(formFile);
            if (imageResult.IsCanceled||imageResult.IsFaulted) return BadRequest(imageResult.Result.Message);
            carImage.ImagePath = imageResult.Result.Message;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Add(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
