using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        public async Task<ActionResult<ServiceResponse<List<GetBrandDto>>>> Get()
        {
            return Ok(await _brandService.FindAll());
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBrandDto>> GetSingle([SwaggerRequestBody(Required = true)] string id)
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
        public void Post([FromBody] [SwaggerRequestBody(Required = true)]
            AddBrandDto brand)
        {
            _brandService.AddBrand(brand);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public async Task<ActionResult<GetBrandDto>> Put([FromBody] [SwaggerRequestBody(Required = true)]
            GetBrandDto brand)
        {
            return Ok(await _brandService.Update(brand));
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetBrandDto>>>> Delete(
            [SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _brandService.DeleteById(id));
        }
    }
}