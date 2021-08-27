using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagement.Application.Dto.CarDto
{
    public class UpdateCarDto
    {
        [Required] public string Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Brand { get; set; }
    }
}