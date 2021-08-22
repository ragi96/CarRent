using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.CarManagement.Application
{
    public class BrandServiceTest
    {
        private readonly IBrandService _service;
        private readonly IMongoRepository<Brand> _repo;
        private readonly IBrandServiceMapper _ownMapper;
        private readonly IMapper _mapper;

        public BrandServiceTest()
        {
            _repo = A.Fake<IMongoRepository<Brand>>();
            _ownMapper = A.Fake<BrandServiceMapper>();
            _mapper = A.Fake<IMapper>();
            _service = new BrandService(_repo, _ownMapper, _mapper);
        }

        [Fact]
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var addBrandDto = A.Fake<AddBrandDto>();

            var answer =_service.AddBrand(addBrandDto);
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