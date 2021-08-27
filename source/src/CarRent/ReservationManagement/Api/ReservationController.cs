using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.ReservationManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService customerService)
        {
            _reservationService = customerService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetReservationDto>>>> Get()
        {
            return Ok(await _reservationService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetReservationDto>>> GetSingle(
            [SwaggerRequestBody(Required = true)] string id)
        {
            try
            {
                return Ok(await _reservationService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Customer {id} " + e.Message);
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] [SwaggerRequestBody(Required = true)]
            AddReservationDto customer)
        {
            _reservationService.Add(customer);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetReservationDto>>> Put([FromBody] [SwaggerRequestBody(Required = true)]
            GetReservationDto customer)
        {
            return Ok(await _reservationService.Update(customer));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetReservationDto>>>> Delete([SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _reservationService.DeleteById(id));
        }
    }
}