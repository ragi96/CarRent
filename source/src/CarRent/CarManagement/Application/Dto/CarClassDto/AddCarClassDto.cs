using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarRent.CarManagement.Application.Dto.CarClassDto
{
    [ExcludeFromCodeCoverage]
    public class AddCarClassDto
    {
        [Required] public string Name { get; set; }

        [Required] public int DailyPrice { get; set; }
    }
}