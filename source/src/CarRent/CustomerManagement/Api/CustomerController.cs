using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.Common.Application.Dto;
using CarRent.Common.Infrastructure;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> Get()
        {
            return Ok(await _customerService.FindAll());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetSingle([SwaggerRequestBody("The ID of the customer", Required = true)] string id)
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
        public void Post([FromBody, SwaggerRequestBody("A customer to add", Required = true)] AddCustomerDto customer)
        {
            _customerService.Add(customer);
        }

        // POST api/<CarController>/search
        [HttpPost]
        [Route("search")]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> Post([FromBody, SwaggerRequestBody("A search term for the fuzzy search", Required = true)] FuzzySearchTerm searchTerm)
        {
            return Ok(await _customerService.Search(searchTerm));
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> Put([FromBody, SwaggerRequestBody("The updated customer", Required = true)] GetCustomerDto customer)
        {
            return Ok(await _customerService.Update(customer));
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([SwaggerRequestBody("The ID of the customer to delete", Required = true)] string id)
        {
            return Ok(await _customerService.DeleteById(id));
        }
    }
}