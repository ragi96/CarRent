using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.InvoiceManagement.Application.Dto;
using CarRent.InvoiceManagement.Application.Mapper;
using CarRent.InvoiceManagement.Domain;
using CarRent.ReservationManagement.Domain;

namespace CarRent.InvoiceManagement.Application
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMongoRepository<Car> _carRepository;
        private readonly IInvoiceMapper _invoiceMapper;
        private readonly IMongoRepository<Invoice> _invoiceRepository;
        private readonly IMongoRepository<Reservation> _reservationRepository;

        public InvoiceService(IMongoRepository<Invoice> invoiceRepository,
            IMongoRepository<Reservation> reservationRepository, IMongoRepository<Car> carRepository,
            IInvoiceMapper invoiceMapper)
        {
            _invoiceMapper = invoiceMapper;
            _invoiceRepository = invoiceRepository;
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
        }

        public async Task<ServiceResponse<GetInvoiceDto>> Create(string reservationId, AddInvoiceDto invoiceDto)
        {
            var serviceResponse = new ServiceResponse<GetInvoiceDto>();
            try
            {
                var reservation = _reservationRepository.GetById(reservationId).Result;
                var car = _carRepository.GetById(invoiceDto.CarId).Result;
                var customer = reservation.Customer.ToEntityAsync().Result;
                var invoice = new Invoice
                {
                    CarClass = reservation.CarClass,
                    Car = car,
                    Customer = customer,
                    StartDate = reservation.StartDate,
                    EndDate = reservation.EndDate
                };
                await _invoiceRepository.Save(invoice);
                await _reservationRepository.DeleteById(reservationId);
            }
            catch (NotFoundException e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetInvoiceDto>> FindOneById(string id)
        {
            var serviceResponse = new ServiceResponse<GetInvoiceDto>();
            var invoice = await _invoiceRepository.GetById(id);
            if (invoice != null)
            {
                serviceResponse.Data = _invoiceMapper.MapToGetDto(invoice);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetInvoiceDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetInvoiceDto>>();
            var invoice = await _invoiceRepository.GetAll();
            serviceResponse.Data = _invoiceMapper.MapToGetDtoList(invoice);
            return serviceResponse;
        }
    }
}