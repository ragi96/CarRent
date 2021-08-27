using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.BrandDto
{
    [ExcludeFromCodeCoverage]
    public class AddBrandDto
    {
        [Required] public string Name { get; set; }
    }
}