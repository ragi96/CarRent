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
        Task<ServiceResponse<CarDto>> AddCar(CarDto carDto);

        Task<ServiceResponse<CarDto>> FindOneById(string id);

        Task<ServiceResponse<IEnumerable<CarDto>>> FindAll();
        Task<ServiceResponse<CarDto>> Update(CarDto carDto);
        Task<ServiceResponse<IEnumerable<CarDto>>> DeleteById(string id);
    }
}
