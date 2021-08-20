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
        Task<ServiceResponse<GetCarDTO>> AddCar(AddCarDTO car);

        Task<ServiceResponse<GetCarDTO>> FindOneById(string id);

        Task<ServiceResponse<IEnumerable<GetCarDTO>>> FindAll();
    }
}
