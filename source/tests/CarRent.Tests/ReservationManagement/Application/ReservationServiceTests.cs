using System.Threading.Tasks;
using AutoMapper;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Dto;
using CarRent.ReservationManagement.Application.Mapper;
using CarRent.ReservationManagement.Domain;
using FakeItEasy;
using Xunit;

namespace CarRent.Tests.ReservationManagement.Application
{
    public class ReservationServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IReservationMapper _ownMapper;
        private readonly IMongoRepository<Reservation> _repo;
        private readonly IReservationService _service;

        public ReservationServiceTests()
        {
            _repo = A.Fake<IMongoRepository<Reservation>>();
            _ownMapper = A.Fake<ReservationMapper>();
            _mapper = A.Fake<IMapper>();
            _service = new ReservationService(_repo, _ownMapper, _mapper);
        }

        [Fact]
        public void Add_MapperDtoToDomainModel_IsCalled()
        {
            var dto = A.Fake<AddReservationDto>();

            var answer = _service.Add(dto);
            A.CallTo(() => _mapper.Map<Reservation>(dto)).MustHaveHappened();
            Assert.IsType<Task<ServiceResponse<GetReservationDto>>>(answer);
        }

        [Fact]
        public void Add_MapperDtoToDm_ReturnsCar()
        {
            var dto = A.Fake<AddReservationDto>();
            var reservation = A.Fake<Reservation>();
            var answer = _service.Add(dto);
            A.CallTo(() => _mapper.Map<Reservation>(dto)).Returns(reservation);
            Assert.IsType<Task<ServiceResponse<GetReservationDto>>>(answer);
        }

        [Fact]
        public void Add_RepoInsertOneAsync_Returns()
        {
            var dto = A.Fake<AddReservationDto>();
            var reservation = A.Fake<Reservation>();

            var answer = _service.Add(dto);
            A.CallTo(() => _repo.Save(reservation)).Returns(A.Fake<Task>());

            Assert.IsType<Task<ServiceResponse<GetReservationDto>>>(answer);
        }

        [Fact]
        public void FindOneById_RepoFindIdAsync_ReturnsTaskCar()
        {
            var id = "asd324a4sda0xsd34234";

            var found = _service.FindOneById(id);
            A.CallTo(() => _repo.GetById(id)).Returns(A.Fake<Task<Reservation>>());

            Assert.IsType<Task<ServiceResponse<GetReservationDto>>>(found);
        }
    }
}