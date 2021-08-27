using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Domain;

namespace CarRent.Common.Application
{
    public class AutoMapping : Profile
    {
        [ExcludeFromCodeCoverage]
        public AutoMapping()
        {
            CreateMap<GetBrandDto, Brand>();
            CreateMap<AddBrandDto, Brand>();

            CreateMap<GetCarClassDto, CarClass>();
            CreateMap<AddCarClassDto, CarClass>();

            CreateMap<GetCarClassDto, Car>();
            CreateMap<UpdateCarDto, Car>();
            CreateMap<AddCarDto, Car>();

            CreateMap<GetCustomerDto, Customer>();
            CreateMap<AddCustomerDto, Customer>();
        }
    }
}