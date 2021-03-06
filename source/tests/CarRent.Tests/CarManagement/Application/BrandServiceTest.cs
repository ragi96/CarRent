using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CarManagement.Application
{
    public class BrandServiceTest
    {
        private readonly IMongoRepository<Car> _carRepo;
        private readonly IMapper _mapper;
        private readonly IBrandMapper _ownMapper;
        private readonly IMongoRepository<Brand> _repo;
        private readonly IBrandService _service;

        public BrandServiceTest()
        {
            _repo = A.Fake<IMongoRepository<Brand>>();
            _ownMapper = A.Fake<BrandMapper>();
            _carRepo = A.Fake<IMongoRepository<Car>>();
            _mapper = A.Fake<IMapper>();
            _service = new BrandService(_repo, _ownMapper, _carRepo, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var addBrandDto = A.Fake<AddBrandDto>();

            var answer = _service.AddBrand(addBrandDto);
            A.CallTo(() => _mapper.Map<Brand>(addBrandDto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetBrandDto>>>(answer);
        }

        [Fact]
        public void AddCar_MapperDtoToDm_ReturnsCar()
        {
            var brandDto = A.Fake<AddBrandDto>();
            var brand = A.Fake<Brand>();
            var answer = _service.AddBrand(brandDto);
            A.CallTo(() => _mapper.Map<Brand>(brandDto)).Returns(brand);
            Assert.IsType<Task<ServiceResponse<GetBrandDto>>>(answer);
        }

        [Fact]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var brandDto = A.Fake<AddBrandDto>();
            var brand = A.Fake<Brand>();

            var answer = _service.AddBrand(brandDto);
            A.CallTo(() => _repo.Save(brand)).Returns(A.Fake<Task>());

            Assert.IsType<Task<ServiceResponse<GetBrandDto>>>(answer);
        }

        [Fact]
        public void FindOneById_MapperDtoToDomainModel_ReturnsGetCarDto()
        {
            var getBrandDto = A.Fake<GetBrandDto>();
            var brand = A.Fake<Car>();
            var id = "asd324a4sda0xsd34234";

            var foundCar = _service.FindOneById(id).Result;
            A.CallTo(() => _mapper.Map<GetBrandDto>(brand)).Returns(getBrandDto);

            Assert.IsType<ServiceResponse<GetBrandDto>>(foundCar);
        }

        [Fact]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCar()
        {
            var id = "asd324a4sda0xsd34234";

            var brand = _service.FindOneById(id);
            A.CallTo(() => _repo.GetById(id)).Returns(A.Fake<Task<Brand>>());

            Assert.IsType<Task<ServiceResponse<GetBrandDto>>>(brand);
        }
    }
}