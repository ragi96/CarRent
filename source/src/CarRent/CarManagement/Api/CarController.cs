using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> Get()
        {
            return Ok(await _carService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> GetSingle(
            [SwaggerRequestBody(Required = true)] string id)
        {
            try
            {
                return Ok(await _carService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Car {id} " + e.Message);
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] AddCarDto car)
        {
            _carService.AddCar(car);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> Put([FromBody] [SwaggerRequestBody(Required = true)]
            UpdateCarDto car)
        {
            return Ok(await _carService.Update(car));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> Delete(
            [SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _carService.DeleteById(id));
        }
    }
}