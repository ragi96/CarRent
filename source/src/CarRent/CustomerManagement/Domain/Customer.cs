using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.CustomerManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Customer")]
    public class Customer : Entity
    {
        public FuzzyString FirstName { get; set; }
        public FuzzyString LastName { get; set; }
        public FuzzyString Street { get; set; }
        public FuzzyString HouseNumber { get; set; }
        public FuzzyString Zip { get; set; }
        public FuzzyString City { get; set; }
    }
}