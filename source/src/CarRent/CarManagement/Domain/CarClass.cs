using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.CarManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("CarClass")]
    public class CarClass : Entity
    {
        public string Name { get; set; }
        public int DailyPrice { get; set; }
    }
}