using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _carService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            return Ok(await _carService.FindOneById(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] CarDto car)
        {
            _carService.AddCar(car);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarDto car)
        {
            return Ok(await _carService.Update(car));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _carService.DeleteById(id));
        }
    }
}
