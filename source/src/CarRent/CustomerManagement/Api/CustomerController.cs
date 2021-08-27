using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.Common.Infrastructure;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Dto.CarDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CustomerManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            try
            {
                return Ok(await _customerService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Customer {id} " + e.Message);
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] AddCustomerDto customer)
        {
            _customerService.Add(customer);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GetCustomerDto customer)
        {
            return Ok(await _customerService.Update(customer));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _customerService.DeleteById(id));
        }
    }
}