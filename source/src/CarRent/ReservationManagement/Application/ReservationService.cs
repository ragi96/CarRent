using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.ReservationManagement.Application.Dto;
using CarRent.ReservationManagement.Application.Mapper;
using CarRent.ReservationManagement.Domain;

namespace CarRent.ReservationManagement.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationMapper _reservationMapper;
        private readonly IMongoRepository<Reservation> _reservationRepository;

        public ReservationService(IMongoRepository<Reservation> reservationRepository,
            IReservationMapper reservationMapper,
            IMapper mapper)
        {
            _reservationMapper = reservationMapper;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetReservationDto>> Add(AddReservationDto customerDto)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            var reservation = _mapper.Map<Reservation>(customerDto);
            await _reservationRepository.Save(reservation);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationDto>> FindOneById(string id)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            var reservation = await _reservationRepository.GetById(id);
            serviceResponse.Data = _reservationMapper.MapToGetDto(reservation);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetReservationDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetReservationDto>>();
            var reservations = await _reservationRepository.GetAll();
            serviceResponse.Data = _reservationMapper.MapToGetDtoList(reservations);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationDto>> Update(GetReservationDto customerDto)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            var reservations = _mapper.Map<Reservation>(customerDto);
            await _reservationRepository.Save(reservations);
            serviceResponse.Data =
                _reservationMapper.MapToGetDto(await _reservationRepository.GetById(reservations.ID));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetReservationDto>>> DeleteById(string id)
        {
            await _reservationRepository.DeleteById(id);
            var serviceResponse = new ServiceResponse<List<GetReservationDto>>();
            var reservations = await _reservationRepository.GetAll();
            serviceResponse.Data = _reservationMapper.MapToGetDtoList(reservations);
            return serviceResponse;
        }
    }
}