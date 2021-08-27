using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.CarDto
{
    [ExcludeFromCodeCoverage]
    public class UpdateCarDto
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int ConstructionYear { get; set; }
        [Required] public string Brand { get; set; }
    }
}