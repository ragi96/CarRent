using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using CarRent.Common.Infrastructure;
using CarRent.InvoiceManagement.Domain;
using CarRent.ReservationManagement.Domain;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _008_SeedInvoiceCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            var reservationRepo = new MongoRepository<Reservation>();

            var carRepo = new MongoRepository<Car>();
            var cars = carRepo.GetAll().Result;

            var rand = new Random();
            for (var i = 0; i < 6; i++)
            {
                var reservations = reservationRepo.GetAll().Result;
                var resNum = rand.Next(0, reservations.Count - 1);
                var carNum = rand.Next(0, cars.Count - 1);
                var reservation = reservations[resNum];
                var customer = reservation.Customer.ToEntityAsync().Result;
                var car = cars[carNum];

                var invoice = new Invoice
                {
                    CarClass = reservation.CarClass,
                    Car = car,
                    Customer = customer,
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate
                };
                await invoice.SaveAsync();
                await reservationRepo.DeleteById(reservation.ID);
            }
        }
    }
}