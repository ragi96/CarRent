using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagement.Application.Dto.BrandDto
{
    public class AddBrandDto
    {
        [Required] public string Name { get; set; }
    }
}