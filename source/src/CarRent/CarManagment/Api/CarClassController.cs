using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Application.Dto.CarClassDto;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _carClassService;

        public CarClassController(ICarClassService carClassService)
        {
            _carClassService = carClassService;
        }
        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _carClassService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            try
            {
                return Ok(await _carClassService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Car {id} " + e.Message);
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] AddCarClassDto carClass)
        {
            _carClassService.AddCarClass(carClass);
        }
        
        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GetCarClassDto carClass)
        {
            return Ok(await _carClassService.Update(carClass));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _carClassService.DeleteById(id));
        }
    }
}
