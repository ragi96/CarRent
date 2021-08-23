using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CarManagment.Application.Dto.CarClassDto
{
    public class AddCarClassDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int DailyPrice { get; set; }
    }
}
