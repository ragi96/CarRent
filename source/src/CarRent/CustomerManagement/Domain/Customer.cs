using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.CustomerManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Customer")]
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}