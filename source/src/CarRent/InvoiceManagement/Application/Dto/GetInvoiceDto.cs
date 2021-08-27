using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CustomerManagement.Application.Dto;
using MongoDB.Entities;

namespace CarRent.InvoiceManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class GetInvoiceDto
    {
        public string Id { get; set; }
        public GetCustomerDto Customer { get; set; }
        public GetCarDto Car { get; set; }
        public GetCarClassDto CarClass { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
        public float Price { get; set; }
    }
}