using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("dtos/getall")]
        public IActionResult GetAllDtos()
        {
            var result = _rentalService.GetAllRentalDetailsDtos();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
