using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagement.Application.Dto.CarDto
{
    public class AddCarDto
    {
        [Required] public string Name { get; set; }

        [Required] public string ConstructionYear { get; set; }

        [Required] public string BrandId { get; set; }

        [Required] public string CarClassId { get; set; }
    }
}