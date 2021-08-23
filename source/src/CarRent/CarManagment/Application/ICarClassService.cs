using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application.Dto.CarClassDto;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagment.Application
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
