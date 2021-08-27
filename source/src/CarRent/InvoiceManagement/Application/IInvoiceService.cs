using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.InvoiceManagement.Application.Dto;

namespace CarRent.InvoiceManagement.Application
{
    public interface IInvoiceService
    {
        Task<ServiceResponse<GetInvoiceDto>> Create(string reservationId, AddInvoiceDto invoiceDto);

        Task<ServiceResponse<GetInvoiceDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetInvoiceDto>>> FindAll();
    }
}