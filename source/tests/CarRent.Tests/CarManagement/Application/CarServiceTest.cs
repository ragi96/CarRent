using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CarManagement.Application
{
    public class CarServiceTest
    {
        private readonly IMongoRepository<Brand> _brandRepo;
        private readonly IMongoRepository<CarClass> _carClassRepo;
        private readonly IMapper _mapper;
        private readonly ICarMapper _ownMapper;
        private readonly IMongoRepository<Car> _repo;
        private readonly ICarService _service;

        public CarServiceTest()
        {
            _repo = A.Fake<IMongoRepository<Car>>();
            _brandRepo = A.Fake<IMongoRepository<Brand>>();
            _carClassRepo = A.Fake<IMongoRepository<CarClass>>();
            _mapper = A.Fake<IMapper>();
            _ownMapper = A.Fake<ICarMapper>();
            _service = new CarService(_repo, _brandRepo, _carClassRepo, _ownMapper, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var carDto = A.Fake<AddCarDto>();

            var answer = _service.AddCar(carDto);
            A.CallTo(() => _mapper.Map<Car>(carDto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(answer);
        }

        [Fact]
        public void AddCar_MapperDtoToDm_ReturnsCar()
        {
            var carDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();
            var answer = _service.AddCar(carDto);
            A.CallTo(() => _mapper.Map<Car>(carDto)).Returns(car);
            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(answer);
        }

        [Fact]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var carDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();

            var answer = _service.AddCar(carDto);
            A.CallTo(() => _repo.Save(car)).Returns(A.Fake<Task>());

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
            A.CallTo(() => _repo.GetById(id)).Returns(A.Fake<Task<Car>>());

            Assert.IsType<Task<ServiceResponse<GetCarDto>>>(car);
        }
    }
}