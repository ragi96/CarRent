using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using MongoDB.Entities;

namespace CarRent.InvoiceManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Invoice")]
    public class Invoice : Entity
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public CarClass CarClass { get; set; }
        public Date StartDate { get; set; }
        public Date EndDate { get; set; }

        [Ignore]
        public float Price
        {
            get => (float) EndDate.DateTime.Date.Subtract(StartDate.DateTime.Date).Days * CarClass.DailyPrice;
        }
    }
}