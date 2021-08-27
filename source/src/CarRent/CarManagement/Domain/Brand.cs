using System.Diagnostics.CodeAnalysis;
using MongoDB.Entities;

namespace CarRent.CarManagement.Domain
{
    [ExcludeFromCodeCoverage]
    [Collection("Brand")]
    public class Brand : Entity
    {
        public string Name { get; set; }
    }
}