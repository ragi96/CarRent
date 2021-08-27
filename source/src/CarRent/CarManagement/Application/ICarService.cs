using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.Common.Application;

namespace CarRent.CarManagement.Application
{
    public interface ICarService
    {
        Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto carDto);

        Task<ServiceResponse<GetCarDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetCarDto>>> FindAll();
        Task<ServiceResponse<GetCarDto>> Update(UpdateCarDto carDto);
        Task<ServiceResponse<List<GetCarDto>>> DeleteById(string id);
    }
}