using System;
using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CustomerManagement.Application.Dto;

namespace CarRent.InvoiceManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class GetInvoiceDto
    {
        public string Id { get; set; }
        public GetCustomerDto Customer { get; set; }
        public GetCarDto Car { get; set; }
        public GetCarClassDto CarClass { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
    }
}