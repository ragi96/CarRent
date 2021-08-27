using System.Threading.Tasks;
using AutoMapper;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.CustomerManagement.Domain;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CustomerManagement.Application
{
    public class CustomerServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ICustomerMapper _ownMapper;
        private readonly IMongoRepository<Customer> _repo;
        private readonly ICustomerService _service;

        public CustomerServiceTests()
        {
            _repo = A.Fake<IMongoRepository<Customer>>();
            _ownMapper = A.Fake<CustomerMapper>();
            _mapper = A.Fake<IMapper>();
            _service = new CustomerService(_repo, _ownMapper, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var dto = A.Fake<AddCustomerDto>();

            var answer = _service.Add(dto);
            A.CallTo(() => _mapper.Map<Customer>(dto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetCustomerDto>>>(answer);
        }

        [Fact]
        public void AddCar_MapperDtoToDm_ReturnsCar()
        {
            var dto = A.Fake<AddCustomerDto>();
            var customer = A.Fake<Customer>();
            var answer = _service.Add(dto);
            A.CallTo(() => _mapper.Map<Customer>(dto)).Returns(customer);
            Assert.IsType<Task<ServiceResponse<GetCustomerDto>>>(answer);
        }

        [Fact]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var dto = A.Fake<AddCustomerDto>();
            var customer = A.Fake<Customer>();

            var answer = _service.Add(dto);
            A.CallTo(() => _repo.Save(customer)).Returns(A.Fake<Task>());

            Assert.IsType<Task<ServiceResponse<GetCustomerDto>>>(answer);
        }

        [Fact]
        public void FindOneById_MapperDtoToDomainModel_ReturnsGetCarDto()
        {
            var dto = A.Fake<GetCustomerDto>();
            var customer = A.Fake<Customer>();
            var id = "asd324a4sda0xsd34234";

            var foundCar = _service.FindOneById(id).Result;
            A.CallTo(() => _mapper.Map<GetCustomerDto>(customer)).Returns(dto);

            Assert.IsType<ServiceResponse<GetCustomerDto>>(foundCar);
        }

        [Fact]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCar()
        {
            var id = "asd324a4sda0xsd34234";

            var brand = _service.FindOneById(id);
            A.CallTo(() => _repo.GetById(id)).Returns(A.Fake<Task<Customer>>());

            Assert.IsType<Task<ServiceResponse<GetCustomerDto>>>(brand);
        }
    }
}