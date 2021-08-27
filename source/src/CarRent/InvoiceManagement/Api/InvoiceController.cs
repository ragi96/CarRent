using System.Threading.Tasks;
using CarRent.Common.Infrastructure;
using CarRent.InvoiceManagement.Application;
using CarRent.InvoiceManagement.Application.Dto;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            return Ok(await _invoiceService.FindAll());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            try
            {
                return Ok(await _invoiceService.FindOneById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound($"Invoice {id} " + e.Message);
            }
        }

        // POST api/<InvoiceController>/5/create-invoice
        [Route("{reservationId}/create-invoice")]
        [HttpPost]
        public async Task<IActionResult> Post(string reservationId, [FromBody] AddInvoiceDto dto)
        {
            try
            {
                return Ok(await _invoiceService.Create(reservationId, dto));
            }
            catch (NotFoundException)
            {
                return NotFound($"Invoice creation failed, ReservationId: {reservationId} or CarId: {dto.CarId} wrong");
            }
        }
    }
}