using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _brandService.FindAll());
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            try
            {
                return Ok(await _brandService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Brand {id} " + e.Message);
            }
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] AddBrandDto brand)
        {
            _brandService.AddBrand(brand);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GetBrandDto brand)
        {
            return Ok(await _brandService.Update(brand));
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _brandService.DeleteById(id));
            }
            catch (NotDeletableException e)
            {
                return ValidationProblem($"Brand {id} " + e.Message);
            }
        }
    }
}