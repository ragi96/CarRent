using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.Common.Application;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.Api
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
        public async Task<ActionResult<ServiceResponse<List<GetCarClassDto>>>> Get()
        {
            return Ok(await _carClassService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarClassDto>>> GetSingle(
            [SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _carClassService.FindOneById(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] [SwaggerRequestBody(Required = true)]
            AddCarClassDto carClass)
        {
            _carClassService.AddCarClass(carClass);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCarClassDto>>> Put(
            [FromBody] [SwaggerRequestBody(Required = true)]
            GetCarClassDto carClass)
        {
            return Ok(await _carClassService.Update(carClass));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCarClassDto>>>> Delete(
            [SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _carClassService.DeleteById(id));
        }
    }
}