using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagement.Application.Dto.CarClassDto
{
    public class AddCarClassDto
    {
        [Required] public string Name { get; set; }

        [Required] public int DailyPrice { get; set; }
    }
}