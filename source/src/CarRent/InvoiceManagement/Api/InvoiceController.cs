using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.InvoiceManagement.Application;
using CarRent.InvoiceManagement.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.InvoiceManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetInvoiceDto>>>> Get()
        {
            return Ok(await _invoiceService.FindAll());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetInvoiceDto>>> GetSingle(
            [SwaggerRequestBody(Required = true)] string id)
        {
            return Ok(await _invoiceService.FindOneById(id));
        }

        // POST api/<InvoiceController>/5/create-invoice
        [Route("{reservationId}/create-invoice")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetInvoiceDto>>> Post(
            [SwaggerRequestBody(Required = true)] string reservationId, [FromBody] [SwaggerRequestBody(Required = true)]
            AddInvoiceDto dto)
        {
            return Ok(await _invoiceService.Create(reservationId, dto));
        }
    }
}