using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagment.Application
{
    public class AddCarDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string BrandId { get; set;  }
    }
}
