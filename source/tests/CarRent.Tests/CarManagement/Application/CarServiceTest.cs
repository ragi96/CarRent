using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CarManagement.Application
{
    public class CarServiceTest
    {
        ICarService _service;
        IMongoRepository<Car> _repo;
        IMapper _mapper;

        public CarServiceTest()
        {
            _repo = A.Fake<IMongoRepository<Car>>();
            _mapper = A.Fake<IMapper>();
            _service = new CarService(_repo, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var addCarDto = A.Fake<AddCarDto>();

            var answer =_service.AddCar(addCarDto);
            A.CallTo(() => _mapper.Map<Car>(addCarDto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(answer);
        }

        [Fact]
        public void AddCar_MapperDtoToDm_ReturnsCar()
        {
            var addCarDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();
            var answer = _service.AddCar(addCarDto);
            A.CallTo(() => _mapper.Map<Car>(addCarDto)).Returns(car);
            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(answer);
        }

        [Fact]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var addCarDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();

            var answer = _service.AddCar(addCarDto);
            A.CallTo(() => _repo.InsertOneAsync(car)).Returns(A.Fake<Task>());

            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(answer);
        }

        [Fact]
        public void FindOneById_MapperDtoToDomainModel_ReturnsGetCarDto()
        {
            var getCarDto = A.Fake<GetCarDto>();
            var car = A.Fake<Car>();
            var id = "asd324a4sda0xsd34234";

            var foundCar = _service.FindOneById(id).Result;
            A.CallTo(() => _mapper.Map<GetCarDto>(car)).Returns(getCarDto);

            Assert.IsType<ServiceResponse<GetCarDto>>(foundCar);
        }

        [Fact]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCar()
        {
            var id = "asd324a4sda0xsd34234";

            var car = _service.FindOneById(id);
            A.CallTo(() => _repo.FindByIdAsync(id)).Returns(A.Fake<Task<Car>>());

            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(car);
        }
    }
}