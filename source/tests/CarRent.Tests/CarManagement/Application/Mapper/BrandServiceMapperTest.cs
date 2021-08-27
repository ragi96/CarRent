using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using Xunit;

namespace CarRent.Tests.CarManagement.Application.Mapper
{
    public class BrandServiceMapperTest
    {
        private readonly BrandMapper _mapper;

        public BrandServiceMapperTest()
        {
            _mapper = new BrandMapper();
        }

        [Fact]
        public void MapToGetBrand_CheckType_ReturnShouldBeGetBrandDto()
        {
            var brand = new Brand {ID = "0xasd34212asdf", Name = "Fiat"};
            var result = _mapper.MapToGetBrandDto(brand);
            Assert.IsType<GetBrandDto>(result);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_NameShouldBeFiat()
        {
            var brand = new Brand {ID = "0xasd34212asdf", Name = "Fiat"};
            var result = _mapper.MapToGetBrandDto(brand);
            Assert.Equal(brand.Name, result.Name);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_IdShouldBe0xasd34212asdf()
        {
            var brand = new Brand {ID = "0xasd34212asdf", Name = "Fiat"};
            var result = _mapper.MapToGetBrandDto(brand);
            Assert.Equal(brand.ID, result.Id);
        }

        [Fact]
        public void MapToGetBrandDtoList_CheckResult_CountShouldBeFive()
        {
            var list = GetTestBrandList();

            var resultList = _mapper.MapToGetBrandDtoList(list);

            Assert.Equal(5, resultList.Count);
        }

        [Fact]
        public void MapToGetBrand_CheckType_ReturnShouldBeListGetBrandDto()
        {
            var list = GetTestBrandList();
            var resultList = _mapper.MapToGetBrandDtoList(list);
            Assert.IsType<List<GetBrandDto>>(resultList);
        }

        private List<Brand> GetTestBrandList()
        {
            var list = new List<Brand>();
            var brand1 = new Brand {ID = "0xasd34212asdf234", Name = "Fiat"};
            list.Add(brand1);
            var brand2 = new Brand {ID = "0xasd5678123axdas", Name = "Ferrari"};
            list.Add(brand2);
            var brand3 = new Brand {ID = "0xasd34212asdfds34", Name = "Lambo"};
            list.Add(brand3);
            var brand4 = new Brand {ID = "0xasd34212asdf12dsf", Name = "Bentley"};
            list.Add(brand4);
            var brand5 = new Brand {ID = "0xasd34212asdf2314ds", Name = "Fiat"};
            list.Add(brand5);


            return list;
        }
    }
}