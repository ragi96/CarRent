using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.CarManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Car")]
    public class Car : Entity
    {
        public string Name { get; set; }
        public int ConstructionYear { get; set; }
        public One<Brand> Brand { get; set; }
        public One<CarClass> CarClass { get; set; }
    }
}