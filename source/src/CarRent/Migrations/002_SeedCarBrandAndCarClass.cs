using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using MongoDB.Entities;

namespace CarRent.Migrations
{
    [ExcludeFromCodeCoverage]
    public class _002_SeedCarBrandAndCarClass : IMigration
    {
        public async Task UpgradeAsync()
        {
            #region carClasses

            var easyClass = new CarClass {DailyPrice = 100, Name = "Einfachklasse"};
            var mediumClass = new CarClass {DailyPrice = 150, Name = "Mittelklasse"};
            var luxuryClass = new CarClass {DailyPrice = 300, Name = "Luxusklasse"};
            await easyClass.SaveAsync();
            await mediumClass.SaveAsync();
            await luxuryClass.SaveAsync();

            #endregion

            #region brands

            var fiat = new Brand {Name = "Fiat"};
            var lambo = new Brand {Name = "Lamborghini"};
            var ferrari = new Brand {Name = "Ferrari"};
            var bmw = new Brand {Name = "BMW"};
            var mercedes = new Brand {Name = "Mercedes-Benz"};
            var hyundai = new Brand {Name = "Hyundai"};
            var tesla = new Brand {Name = "Tesla"};
            var audi = new Brand {Name = "Audi"};
            await fiat.SaveAsync();
            await lambo.SaveAsync();
            await ferrari.SaveAsync();
            await bmw.SaveAsync();
            await mercedes.SaveAsync();
            await hyundai.SaveAsync();
            await tesla.SaveAsync();
            await audi.SaveAsync();

            #endregion

            #region cars

            var fiat500 = new Car {ConstructionYear = 2019, Name = "500"};
            fiat500.Brand = fiat;
            fiat500.CarClass = easyClass;
            await fiat500.SaveAsync();

            var fiatPanda = new Car {ConstructionYear = 2020, Name = "Panda"};
            fiatPanda.Brand = fiat;
            fiatPanda.CarClass = easyClass;
            await fiatPanda.SaveAsync();

            var lamboAventador = new Car {ConstructionYear = 2021, Name = "Aventador LP 780-4 Ultimae"};
            lamboAventador.Brand = lambo;
            lamboAventador.CarClass = luxuryClass;
            await lamboAventador.SaveAsync();

            var lamboUrus = new Car {ConstructionYear = 2020, Name = "Urus"};
            lamboUrus.Brand = lambo;
            lamboUrus.CarClass = mediumClass;
            await lamboUrus.SaveAsync();

            var ferrariF50 = new Car {ConstructionYear = 1996, Name = "F50"};
            ferrariF50.Brand = ferrari;
            ferrariF50.CarClass = luxuryClass;
            await ferrariF50.SaveAsync();

            var bmwm3 = new Car {ConstructionYear = 2020, Name = "M3"};
            bmwm3.Brand = bmw;
            bmwm3.CarClass = mediumClass;
            await bmwm3.SaveAsync();

            var mercedesG = new Car {ConstructionYear = 2016, Name = "G 63 AMG 6x6"};
            mercedesG.Brand = mercedes;
            mercedesG.CarClass = luxuryClass;
            await mercedesG.SaveAsync();

            var hyundaiI30 = new Car {ConstructionYear = 2021, Name = "i30"};
            hyundaiI30.Brand = hyundai;
            hyundaiI30.CarClass = easyClass;
            await hyundaiI30.SaveAsync();

            var teslaX = new Car {ConstructionYear = 2020, Name = "Model X"};
            teslaX.Brand = tesla;
            teslaX.CarClass = mediumClass;
            await teslaX.SaveAsync();

            var tesla3 = new Car {ConstructionYear = 2018, Name = "Model 3"};
            tesla3.Brand = tesla;
            tesla3.CarClass = mediumClass;
            await tesla3.SaveAsync();

            var audiA1 = new Car {ConstructionYear = 2019, Name = "A1"};
            audiA1.Brand = audi;
            audiA1.CarClass = easyClass;
            await audiA1.SaveAsync();

            var audiEtron = new Car {ConstructionYear = 2021, Name = "e-tron GT"};
            audiEtron.Brand = audi;
            audiEtron.CarClass = luxuryClass;
            await audiEtron.SaveAsync();

            #endregion
        }
    }
}