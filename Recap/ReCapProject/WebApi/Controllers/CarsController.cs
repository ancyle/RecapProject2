using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbycolor")]
        public IActionResult GetAllByColor([FromQuery, Required] int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbybrand")]
        public IActionResult GetAllByBrand([FromQuery, Required] int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("dtos/getall")]
        public IActionResult GetAllDtos()
        {
            var result = _carService.GetAllCarsDtos();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("dtos/getallbycolor")]
        public IActionResult GetAllDtosByColor([FromQuery, Required] string colorName)
        {
            var result = _carService.GetAllCarsDtosByColor(colorName);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("dtos/getallbybrand")]
        public IActionResult GetAllDtosByBrand([FromQuery, Required] string brandName)
        {
            var result = _carService.GetAllCarsDtosByBrand(brandName);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("dtos/getbyid")]
        public IActionResult GetDtoById([FromQuery, Required] int carId)
        {
            var result = _carService.GetCarDetailDtoById(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery, Required] int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
