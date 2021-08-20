using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.Connection;
using CarRent.Controllers;
using FakeItEasy;
using FakeItEasy.Sdk;
using NUnit.Framework;

namespace CarRent.Tests.CarManagement.Application
{
    [TestFixture]
    class CarServiceTest
    {
        ICarService _service;
        IMongoRepository<Car> _repo;
        IMapper _mapper;

        [SetUp]
        public void Init()
        {
            _repo = A.Fake<IMongoRepository<Car>>();
            _mapper = A.Fake<IMapper>();
            _service = new CarService(_repo, _mapper);
        }

        [Test] 
        public void AddCar_MapperDtoToDomainModel_IsCalled()
        {
            var addCarDto = A.Fake<AddCarDto>();

            _service.AddCar(addCarDto);
            A.CallTo(() => _mapper.Map<Car>(addCarDto)).MustHaveHappened();
        }

        [Test]
        public void AddCar_MapperDtoToDm_ReturnsCar()
        {
            var addCarDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();
            _service.AddCar(addCarDto);
            A.CallTo(() => _mapper.Map<Car>(addCarDto)).Returns(car);
        }

        [Test]
        public void AddCar_RepoInsertOneAsync_Returns()
        {
            var addCarDto = A.Fake<AddCarDto>();
            var car = A.Fake<Car>();
            _service.AddCar(addCarDto);
            A.CallTo(() => _repo.InsertOneAsync(car)).Returns(A.Fake<Task>());
        }

        [Test]
        public void FindOneById_MapperDtoToDomainModel_ReturnsGetCarDto()
        {
            var getCarDto = A.Fake<GetCarDto>();
            var car = A.Fake<Car>();
            var id = "asd324a4sda0xsd34234";

            _service.FindOneById(id);
            A.CallTo(() => _mapper.Map<GetCarDto>(car)).Returns(getCarDto);
        }

        [Test]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCar()
        {
            var id = "asd324a4sda0xsd34234";

            _service.FindOneById(id);
            A.CallTo(() => _repo.FindByIdAsync(id)).Returns(A.Fake<Task<Car>>());
        }
    }
}
