using System.Collections.Generic;
using CarRent.ReservationManagement.Application.Dto;
using CarRent.ReservationManagement.Domain;

namespace CarRent.ReservationManagement.Application.Mapper
{
    public interface IReservationMapper
    {
        GetReservationDto MapToGetDto(Reservation reservation);

        List<GetReservationDto> MapToGetDtoList(List<Reservation> reservationList);
    }
}