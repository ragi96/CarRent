using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CustomerManagement.Application.Dto
{
    [ExcludeFromCodeCoverage]
    public class AddCustomerDto
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string HouseNumber { get; set; }
        [Required] public string Zip { get; set; }
        [Required] public string City { get; set; }
    }
}