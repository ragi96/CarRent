using MongoDB.Entities;

namespace CarRent.CarManagement.Domain
{
    [Collection("Brand")]
    public class Brand : Entity
    {
        public string Name { get; set; }
    }
}