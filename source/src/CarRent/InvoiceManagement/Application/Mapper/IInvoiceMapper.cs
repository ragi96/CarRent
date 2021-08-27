using System.Collections.Generic;
using CarRent.InvoiceManagement.Application.Dto;
using CarRent.InvoiceManagement.Domain;

namespace CarRent.InvoiceManagement.Application.Mapper
{
    public interface IInvoiceMapper
    {
        GetInvoiceDto MapToGetDto(Invoice invoice);

        List<GetInvoiceDto> MapToGetDtoList(List<Invoice> invoiceList);
    }
}