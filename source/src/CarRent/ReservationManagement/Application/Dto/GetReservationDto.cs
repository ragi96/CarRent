using System;
using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CustomerManagement.Application.Dto;

namespace CarRent.ReservationManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class GetReservationDto
    {
        public string Id { get; set; }
        public GetCustomerDto Customer { get; set; }
        public GetCarDto WishCar { get; set; }
        public GetCarClassDto CarClass { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}