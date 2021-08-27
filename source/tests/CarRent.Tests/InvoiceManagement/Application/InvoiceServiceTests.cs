using CarRent.CarManagement.Domain;
using CarRent.Common.Infrastructure;
using CarRent.InvoiceManagement.Application;
using CarRent.InvoiceManagement.Application.Mapper;
using CarRent.InvoiceManagement.Domain;
using CarRent.ReservationManagement.Domain;
using FakeItEasy;

namespace CarRent.Tests.InvoiceManagement.Application
{
    public class InvoiceServiceTests
    {
        private readonly IMongoRepository<Car> _carRepo;
        private readonly IInvoiceMapper _ownMapper;
        private readonly IMongoRepository<Invoice> _repo;
        private readonly IMongoRepository<Reservation> _reservationRepo;
        private readonly IInvoiceService _service;

        public InvoiceServiceTests()
        {
            _repo = A.Fake<IMongoRepository<Invoice>>();
            _carRepo = A.Fake<IMongoRepository<Car>>();
            _reservationRepo = A.Fake<IMongoRepository<Reservation>>();
            _ownMapper = A.Fake<InvoiceMapper>();
            _service = new InvoiceService(_repo, _reservationRepo, _carRepo, _ownMapper);
        }
    }
}