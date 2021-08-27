using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using CarRent.Common.Infrastructure;
using CarRent.CustomerManagement.Domain;
using CarRent.ReservationManagement.Domain;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _006_SeedReservations : IMigration
    {
        public async Task UpgradeAsync()
        {
            var custRepo = new MongoRepository<Customer>();
            var customers = custRepo.GetAll().Result;
            var carRepo = new MongoRepository<Car>();
            var cars = carRepo.GetAll().Result;
            var carClassRepo = new MongoRepository<CarClass>();
            var carClasses = carClassRepo.GetAll().Result;

            var rand = new Random();
            for (var i = 0; i < 20; i++)
            {
                var custNum = rand.Next(0, customers.Count - 1);
                var carNum = rand.Next(0, cars.Count - 1);
                var carClassNum = rand.Next(0, carClasses.Count - 1);
                var customer = customers[custNum];
                var car = cars[carNum];
                var carClass = carClasses[carClassNum];

                var startDate = RandomDay();
                var endDate = RandomDay();
                do
                {
                    endDate = RandomDay();
                } while (startDate < endDate);


                var res = new Reservation {EndDate = startDate, StartDate = endDate};
                res.Customer = customer;
                res.WishCar = car;
                res.CarClass = carClass;
                await res.SaveAsync();
            }
        }

        public DateTime RandomDay()
        {
            var gen = new Random();
            var start = new DateTime(2020, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}