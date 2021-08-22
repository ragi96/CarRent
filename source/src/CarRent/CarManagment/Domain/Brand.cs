using MongoDB.Entities;

namespace CarRent.CarManagment.Domain
{
    [Collection("Brand")]
    public class Brand : Entity
    {
        public string Name { get; set; }
    }
}
