using MongoDB.Entities;

namespace CarRent.CarManagment.Domain
{
    [Collection("Car")]
    public class Car : Entity
    {
        public string Name { get; set; }
        public One<Brand> Brand { get; set; }

    }
}
