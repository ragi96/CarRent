using System.Collections.Generic;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.CustomerManagement.Domain;
using Xunit;

namespace CarRent.Tests.CustomerManagement.Application.Mapper
{
    public class CustomerMapperTests
    {
        private readonly CustomerMapper _mapper;

        public CustomerMapperTests()
        {
            _mapper = new CustomerMapper();
        }

        [Fact]
        public void MapToGetBrand_CheckType_ReturnShouldBeGetDto()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Fürth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.IsType<GetCustomerDto>(result);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_FirstNameShouldBePaul()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Fürth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.FirstName, result.FirstName);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_LastNameShouldBeFurth()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Furth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.LastName, result.LastName);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_StreetShouldBeBahn()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Furth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.Street, result.Street);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_HouseNumberShouldBe2a()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Furth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.HouseNumber, result.HouseNumber);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_ZipShouldBe9000()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Furth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.Zip, result.Zip);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_CityShouldBeSG()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Furth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.City, result.City);
        }

        [Fact]
        public void MapToGetBrand_CheckResult_IdShouldBe0x45465asdas12312d()
        {
            var customer = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Fürth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            var result = _mapper.MapToGetDto(customer);
            Assert.Equal(customer.ID, result.Id);
        }

        [Fact]
        public void MapToGetBrandDtoList_CheckResult_CountShouldBeFive()
        {
            var list = GetTestCustomerList();

            var resultList = _mapper.MapToGetDtoList(list);

            Assert.Equal(5, resultList.Count);
        }

        [Fact]
        public void MapToGetBran_CheckType_ReturnShouldBeListGetBrandDto()
        {
            var list = GetTestCustomerList();
            var resultList = _mapper.MapToGetDtoList(list);
            Assert.IsType<List<GetCustomerDto>>(resultList);
        }

        private static List<Customer> GetTestCustomerList()
        {
            var list = new List<Customer>();
            var cust1 = new Customer
            {
                ID = "0x45465asdas12312d", FirstName = "Paul", LastName = "Fürth", Street = "Bahnhofstrasse",
                HouseNumber = "2a", Zip = "9000", City = "St. Gallen"
            };
            list.Add(cust1);
            var cust2 = new Customer
            {
                ID = "0x45465asdasdasdas", FirstName = "Philippe", LastName = "Gabriaux", Street = "Via dalla Staziun",
                HouseNumber = "31", Zip = "8374", City = "Dussnang"
            };
            list.Add(cust2);
            var cust3 = new Customer
            {
                ID = "0x45465as123dasd", FirstName = "Wolfgang", LastName = "Mehler", Street = "Via Pestariso",
                HouseNumber = "53", Zip = "9016", City = "St. Gallen"
            };
            list.Add(cust3);
            var cust4 = new Customer
            {
                ID = "0x45465as576546dasd", FirstName = "Olum", LastName = "Golobus", Street = "Schwägalpstrasse",
                HouseNumber = "12", Zip = "9107", City = "Urnäsch"
            };
            list.Add(cust4);
            var cust5 = new Customer
            {
                ID = "0x45465acv43sdasd", FirstName = "Kevin", LastName = "Neumann", Street = "Sonnenbergstr",
                HouseNumber = "170", Zip = "5620", City = "Bremgarten"
            };
            list.Add(cust5);

            return list;
        }
    }
}