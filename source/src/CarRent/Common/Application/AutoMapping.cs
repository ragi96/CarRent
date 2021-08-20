using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;

namespace CarRent.Common.Application
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<Car, GetCarDto>();
            CreateMap<GetCarDto, Car>();
            CreateMap<AddCarDto, Car>();
        }
    }
}
