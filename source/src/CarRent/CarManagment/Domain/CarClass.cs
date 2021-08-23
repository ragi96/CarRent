using MongoDB.Entities;

namespace CarRent.CarManagment.Domain
{
    [Collection("CarClass")]
    public class CarClass : Entity
    {
        public string Name { get; set; }
        public int DailyPrice { get; set; }

    }
}
