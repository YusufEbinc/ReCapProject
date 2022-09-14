using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
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

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-id")]
        public IActionResult Get(int id)
        {
            var result = _carService.Get(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get-brand-id")]
        public IActionResult GetBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-color-id")]
        public IActionResult GetColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get-car-details")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add-car")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update-car")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

       [HttpPost("delete-car")]
       public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
