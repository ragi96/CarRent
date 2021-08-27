using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.BrandDto
{
    [ExcludeFromCodeCoverage]
    public class GetBrandDto
    {
        [Required] public string Id { get; set; }

        [Required] public string Name { get; set; }
    }
}