using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using Xunit;

namespace CarRent.Tests.CarManagement.Application.Mapper
{
    public class CarClassServiceMapperTest
    {
        private readonly CarClassMapper _mapper;

        public CarClassServiceMapperTest()
        {
            _mapper = new CarClassMapper();
        }

        [Fact]
        public void MapToGetCarClass_CheckType_ReturnShouldBeGetCarClassDto()
        {
            var carClass = new CarClass {ID = "0xasd34212asdf", Name = "Einfachklasse", DailyPrice = 10};
            var result = _mapper.MapToGetCarClassDto(carClass);
            Assert.IsType<GetCarClassDto>(result);
        }

        [Fact]
        public void MapToGetCarClass_CheckResult_NameShouldBeEinfachklasse()
        {
            var carClass = new CarClass {ID = "0xasd34212asdf", Name = "Einfachklasse", DailyPrice = 10};
            var result = _mapper.MapToGetCarClassDto(carClass);
            Assert.Equal(carClass.Name, result.Name);
        }

        [Fact]
        public void MapToGetCarClass_CheckResult_IdShouldBe0xasd34212asdf()
        {
            var carClass = new CarClass {ID = "0xasd34212asdf", Name = "Einfachklasse", DailyPrice = 10};
            var result = _mapper.MapToGetCarClassDto(carClass);
            Assert.Equal(carClass.ID, result.Id);
        }

        [Fact]
        public void MapToGetCarClass_CheckResult_DailyPriceShouldBeTen()
        {
            var carClass = new CarClass {ID = "0xasd34212asdf", Name = "Einfachklasse", DailyPrice = 10};
            var result = _mapper.MapToGetCarClassDto(carClass);
            Assert.Equal(carClass.DailyPrice, result.DailyPrice);
        }

        [Fact]
        public void MapToGetCarClassDtoList_CheckResult_CountShouldBeThree()
        {
            var list = GetTestCarClassList();

            var resultList = _mapper.MapToGetCarClassDtoList(list);

            Assert.Equal(3, resultList.Count);
        }

        [Fact]
        public void MapToGetCarClass_CheckType_ReturnShouldBeListGetCarClassDto()
        {
            var list = GetTestCarClassList();
            var resultList = _mapper.MapToGetCarClassDtoList(list);
            Assert.IsType<List<GetCarClassDto>>(resultList);
        }

        private List<CarClass> GetTestCarClassList()
        {
            var list = new List<CarClass>();
            var carClass1 = new CarClass {ID = "0xasd34212asdf234", Name = "Einfachklasse", DailyPrice = 10};
            list.Add(carClass1);
            var carClass2 = new CarClass {ID = "0xasd5678123axdas", Name = "Mittelklasse", DailyPrice = 20};
            list.Add(carClass2);
            var carClass3 = new CarClass {ID = "0xasd34212asdfds34", Name = "Luxuswagen", DailyPrice = 30};
            list.Add(carClass3);


            return list;
        }
    }
}