using System;
using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using MongoDB.Entities;

namespace CarRent.ReservationManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Reservation")]
    public class Reservation : Entity
    {
        public One<Customer> Customer { get; set; }
        public Car WishCar { get; set; }
        public CarClass CarClass { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }
    }
}