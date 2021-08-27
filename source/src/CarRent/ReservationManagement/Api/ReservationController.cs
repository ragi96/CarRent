using System.Threading.Tasks;
using CarRent.Common.Infrastructure;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Dto;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            return Ok(await _reservationService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
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
        public void Post([FromBody] AddReservationDto customer)
        {
            _reservationService.Add(customer);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GetReservationDto customer)
        {
            return Ok(await _reservationService.Update(customer));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _reservationService.DeleteById(id));
        }
    }
}