using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.ReservationManagement.Application.Dto;

namespace CarRent.ReservationManagement.Application
{
    public interface IReservationService
    {
        Task<ServiceResponse<GetReservationDto>> Add(AddReservationDto customerDto);

        Task<ServiceResponse<GetReservationDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetReservationDto>>> FindAll();
        Task<ServiceResponse<GetReservationDto>> Update(GetReservationDto customerDto);
        Task<ServiceResponse<List<GetReservationDto>>> DeleteById(string id);
    }
}