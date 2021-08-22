﻿using System;
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
        Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto carDto);

        Task<ServiceResponse<GetCarDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetCarDto>>> FindAll();
        Task<ServiceResponse<GetCarDto>> Update(UpdateCarDto carDto);
        Task<ServiceResponse<List<GetCarDto>>> DeleteById(string id);
    }
}
