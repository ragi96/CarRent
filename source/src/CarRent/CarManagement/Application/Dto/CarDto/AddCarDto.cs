using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.CarDto
{
    [ExcludeFromCodeCoverage]
    public class AddCarDto
    {
        [Required] public string Name { get; set; }

        [Required] public int ConstructionYear { get; set; }

        [Required] public string BrandId { get; set; }

        [Required] public string CarClassId { get; set; }
    }
}