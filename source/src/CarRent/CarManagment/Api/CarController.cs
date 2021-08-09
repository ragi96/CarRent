using System.Collections.Generic;
using CarRent.CarManagment.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: api/<CorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CorController>
        [HttpPost]
        public void Post([FromBody] CarDTO value)
        {
        }

        // PUT api/<CorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarDTO value)
        {
        }

        // DELETE api/<CorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
