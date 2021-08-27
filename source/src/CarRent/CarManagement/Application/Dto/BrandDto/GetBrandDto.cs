using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagement.Application.Dto.BrandDto
{
    public class GetBrandDto
    {
        [Required] public string Id { get; set; }

        [Required] public string Name { get; set; }
    }
}