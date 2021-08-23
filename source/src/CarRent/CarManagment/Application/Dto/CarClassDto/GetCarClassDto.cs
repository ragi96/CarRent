using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagment.Application
{
    public class GetCarClassDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DailyPrice { get; set; }
    }
}
