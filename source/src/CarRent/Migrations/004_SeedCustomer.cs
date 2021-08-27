using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CustomerManagement.Domain;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _004_SeedCustomerCollection : IMigration
    {
        public async Task UpgradeAsync()
        {
            var cust1 = new Customer
            {
                FirstName = "Paul", LastName = "Fürth", Street = "Bahnhofstrasse", HouseNumber = "2a", Zip = "9000",
                City = "St. Gallen"
            };
            await cust1.SaveAsync();
            var cust2 = new Customer
            {
                FirstName = "Fleurette", LastName = "Marcoux", Street = "Im Wingert", HouseNumber = "72", Zip = "2525",
                City = "Le Landeron"
            };
            await cust2.SaveAsync();
            var cust3 = new Customer
            {
                FirstName = "Rémy", LastName = "Landry", Street = "Valéestrasse", HouseNumber = "96", Zip = "1317",
                City = "Orny"
            };
            await cust3.SaveAsync();
            var cust4 = new Customer
            {
                FirstName = "Ulrike", LastName = "Koch", Street = "Höhenweg ", HouseNumber = "46", Zip = "8231",
                City = "Hemmental"
            };
            await cust4.SaveAsync();
            var cust5 = new Customer
            {
                FirstName = "Timothée", LastName = "Roussel", Street = "Lützelflühstrasse ", HouseNumber = "158",
                Zip = "9500", City = "Wil"
            };
            await cust5.SaveAsync();
            var cust6 = new Customer
            {
                FirstName = "Philippe", LastName = "Gabriaux", Street = "Via dalla Staziun", HouseNumber = "31",
                Zip = "8374", City = "Dussnang"
            };
            await cust6.SaveAsync();
            var cust7 = new Customer
            {
                FirstName = "Wolfgang", LastName = "Mehler", Street = "Via Pestariso", HouseNumber = "53", Zip = "9016",
                City = "St. Gallen"
            };
            await cust7.SaveAsync();
            var cust8 = new Customer
            {
                FirstName = "Olum", LastName = "Golobus", Street = "Schwägalpstrasse", HouseNumber = "12", Zip = "9107",
                City = "Urnäsch"
            };
            await cust8.SaveAsync();
            var cust9 = new Customer
            {
                FirstName = "Kevin", LastName = "Neumann", Street = "Sonnenbergstr", HouseNumber = "170", Zip = "5620",
                City = "Bremgarten"
            };
            await cust9.SaveAsync();
            var cust10 = new Customer
            {
                FirstName = "Michael V ", LastName = "Faerber", Street = "Brunnacherstrasse", HouseNumber = "1030",
                Zip = "8058", City = "Zürich"
            };
            await cust10.SaveAsync();
        }
    }
}