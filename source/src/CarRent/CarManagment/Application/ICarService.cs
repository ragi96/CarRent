using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagment.Application
{
    public interface ICarService
    {
        Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto car);

        Task<ServiceResponse<GetCarDto>> FindOneById(string id);

        Task<ServiceResponse<IEnumerable<GetCarDto>>> FindAll();
        Task<ServiceResponse<GetCarDto>> Update(GetCarDto car);
        Task<ServiceResponse<IEnumerable<GetCarDto>>> DeleteById(string id);
    }
}
