using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using MongoDB.Bson;

namespace CarRent.Common.Application
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<Car, GetCarDto>();
            CreateMap<GetCarDto, Car>().ForMember(getCarDto => getCarDto.Id, car => car.MapFrom(s => new ObjectId(s.Id)));
            CreateMap<AddCarDto, Car>().ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<Brand, GetBrandDto>();
            CreateMap<GetBrandDto, Brand>().ForMember(getCarDto => getCarDto.Id, car => car.MapFrom(s => new ObjectId(s.Id)));
            CreateMap<AddBrandDto, Brand>().ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
