using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.Common.Application;

namespace CarRent.CarManagement.Application
{
    public interface ICarClassService
    {
        Task<ServiceResponse<GetCarClassDto>> AddCarClass(AddCarClassDto carClassDto);

        Task<ServiceResponse<GetCarClassDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetCarClassDto>>> FindAll();
        Task<ServiceResponse<GetCarClassDto>> Update(GetCarClassDto carDto);
        Task<ServiceResponse<List<GetCarClassDto>>> DeleteById(string id);
    }
}