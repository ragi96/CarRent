using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CarManagement.Application
{
    public class CarClassSericeTest
    {
        private readonly IMongoRepository<Car> _carRepo;
        private readonly IMapper _mapper;
        private readonly ICarClassServiceMapper _ownMapper;
        private readonly IMongoRepository<CarClass> _repo;
        private readonly ICarClassService _service;

        public CarClassSericeTest()
        {
            _repo = A.Fake<IMongoRepository<CarClass>>();
            _ownMapper = A.Fake<CarClassServiceMapper>();
            _carRepo = A.Fake<IMongoRepository<Car>>();
            _mapper = A.Fake<IMapper>();
            _service = new CarClassService(_repo, _carRepo, _ownMapper, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var addCarClassDto = A.Fake<AddCarClassDto>();

            var answer = _service.AddCarClass(addCarClassDto);
            A.CallTo(() => _mapper.Map<CarClass>(addCarClassDto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetCarClassDto>>>(answer);
        }

        [Fact]
        public void AddCar_MapperDtoToDm_ReturnsCarClass()
        {
            var carClassDto = A.Fake<AddCarClassDto>();
            var carClass = A.Fake<CarClass>();
            var answer = _service.AddCarClass(carClassDto);
            A.CallTo(() => _mapper.Map<CarClass>(carClassDto)).Returns(carClass);
            Assert.IsType<Task<ServiceResponse<GetCarClassDto>>>(answer);
        }

        [Fact]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var dto = A.Fake<AddCarClassDto>();
            var carClass = A.Fake<CarClass>();

            var answer = _service.AddCarClass(dto);
            A.CallTo(() => _repo.Save(carClass)).Returns(A.Fake<Task>());

            Assert.IsType<Task<ServiceResponse<GetCarClassDto>>>(answer);
        }

        [Fact]
        public void FindOneById_MapperDtoToDomainModel_ReturnsGetCarClassDto()
        {
            var getCarClassDto = A.Fake<GetCarClassDto>();
            var carClass = A.Fake<CarClass>();
            var id = "asd324a4sda0xsd34234";

            var foundCar = _service.FindOneById(id).Result;
            A.CallTo(() => _mapper.Map<GetCarClassDto>(carClass)).Returns(getCarClassDto);

            Assert.IsType<ServiceResponse<GetCarClassDto>>(foundCar);
        }

        [Fact]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCarClass()
        {
            var id = "asd324a4sda0xsd34234";

            var carClass = _service.FindOneById(id);
            A.CallTo(() => _repo.GetById(id)).Returns(A.Fake<Task<CarClass>>());

            Assert.IsType<Task<ServiceResponse<GetCarClassDto>>>(carClass);
        }
    }
}