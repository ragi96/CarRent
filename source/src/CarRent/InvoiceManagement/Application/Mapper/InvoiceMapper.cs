using System.Collections.Generic;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.InvoiceManagement.Application.Dto;
using CarRent.InvoiceManagement.Domain;
using CarRent.ReservationManagement.Application.Dto;

namespace CarRent.InvoiceManagement.Application.Mapper
{
    public class InvoiceMapper : IInvoiceMapper
    {
        private readonly CarMapper _carMapper;
        private readonly CarClassMapper _carClassMapper;
        private readonly CustomerMapper _customerMapper;

        public InvoiceMapper()
        {
            _customerMapper = new CustomerMapper();
            _carClassMapper = new CarClassMapper();
            _carMapper = new CarMapper();
        }

        public GetInvoiceDto MapToGetDto(Invoice invoice)
        {
            return new GetInvoiceDto()
            {
                Id = invoice.ID,
                Customer = _customerMapper.MapToGetDto(invoice.Customer),
                CarClass = _carClassMapper.MapToGetCarClassDto(invoice.CarClass),
                Car = _carMapper.MapToGetCarDto(invoice.Car),
                EndDate = invoice.EndDate,
                StartDate = invoice.StartDate,
                Price = invoice.Price,
            };
        }

        public List<GetInvoiceDto> MapToGetDtoList(List<Invoice> invoiceList)
        {
            var getDtoList = new List<GetInvoiceDto>();
            foreach (var invoice in invoiceList) getDtoList.Add(MapToGetDto(invoice));
            return getDtoList;
        }
    }
}