using MongoDB.Entities;

namespace CarRent.CarManagement.Domain
{
    [Collection("CarClass")]
    public class CarClass : Entity
    {
        public string Name { get; set; }
        public int DailyPrice { get; set; }
    }
}