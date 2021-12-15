using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandidandcolorid")]
        public IActionResult GetByBrandIdAndColorId(int brandId, int colorId)
        {
            var result = _carService.GetByBrandIdAndColorId(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(int min, int max)
        {
            var result = _carService.GetByDailyPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _carService.GetDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbyid")]
        public IActionResult GetDetailsById(int id)
        {
            var result = _carService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbybrandname")]
        public IActionResult GetDetailsByBrandName(string name)
        {
            var result = _carService.GetDetailsByBrandName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbycolorname")]
        public IActionResult GetDetailsByColorName(string name)
        {
            var result = _carService.GetDetailsByColorName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbybrandnameandcolorname")]
        public IActionResult GetDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            var result = _carService.GetDetailsByBrandNameAndColorName(brandName, colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailsbydailyprice")]
        public IActionResult GetDetailsByDailyPrice(int min, int max)
        {
            var result = _carService.GetDetailsByDailyPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
