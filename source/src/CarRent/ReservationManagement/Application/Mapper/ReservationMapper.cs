using System.Collections.Generic;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.ReservationManagement.Application.Dto;
using CarRent.ReservationManagement.Domain;

namespace CarRent.ReservationManagement.Application.Mapper
{
    public class ReservationMapper : IReservationMapper
    {
        private readonly CarClassMapper _carClassMapper;
        private readonly CarMapper _carMapper;

        private readonly CustomerMapper _customerMapper;

        public ReservationMapper()
        {
            _customerMapper = new CustomerMapper();
            _carClassMapper = new CarClassMapper();
            _carMapper = new CarMapper();
        }

        public GetReservationDto MapToGetDto(Reservation reservation)
        {
            var customer = reservation.Customer.ToEntityAsync().Result;
            return new GetReservationDto()
            {
                Id = reservation.ID,
                Customer = _customerMapper.MapToGetDto(customer),
                CarClass = _carClassMapper.MapToGetCarClassDto(reservation.CarClass),
                WishCar = _carMapper.MapToGetCarDto(reservation.WishCar),
                EndDate = reservation.EndDate,
                StartDate = reservation.StartDate
            };
        }

        public List<GetReservationDto> MapToGetDtoList(List<Reservation> reservationList)
        {
            var getDtoList = new List<GetReservationDto>();
            foreach (var reservation in reservationList) getDtoList.Add(MapToGetDto(reservation));

            return getDtoList;
        }
    }
}