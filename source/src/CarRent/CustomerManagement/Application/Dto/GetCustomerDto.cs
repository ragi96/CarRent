using System.Diagnostics.CodeAnalysis;

namespace CarRent.CustomerManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class GetCustomerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}