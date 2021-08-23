using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
using CarRent.CarManagment.Application.Dto.CarClassDto;
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using MongoDB.Bson;

namespace CarRent.CarManagment.Application
{
    public class CarClassService : ICarClassService
    {
        private readonly IMongoRepository<CarClass> _carClassRepository;
        private readonly IMongoRepository<Car> _carRepository;

        private readonly ICarClassServiceMapper _carClassMapper;
        private readonly IMapper _mapper;

        public CarClassService(IMongoRepository<CarClass> carClassRepository, IMongoRepository<Car> carRepository, ICarClassServiceMapper carClassMapper, IMapper mapper)
        {
            _carClassRepository = carClassRepository;
            _carRepository = carRepository;
            _carClassMapper = carClassMapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCarClassDto>> AddCarClass(AddCarClassDto carClassDto)
        {
            var serviceResponse = new ServiceResponse<GetCarClassDto>();
            var carClass = _mapper.Map<CarClass>(carClassDto);
            await _carClassRepository.Save(carClass);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarClassDto>> FindOneById(string id)
        {
            var serviceResponse = new ServiceResponse<GetCarClassDto>(); 
            var tCar = await _carClassRepository.GetById(id);
            serviceResponse.Data = _carClassMapper.MapToGetCarClassDto(tCar);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarClassDto>>> FindAll()
        { 
            var serviceResponse = new ServiceResponse<List<GetCarClassDto>>(); 
            var carClasses = await _carClassRepository.GetAll(); 
            serviceResponse.Data = _carClassMapper.MapToGetCarClassList(carClasses); 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarClassDto>> Update(GetCarClassDto carDto)
        {
            var serviceResponse = new ServiceResponse<GetCarClassDto>();
            var car = _mapper.Map<CarClass>(carDto);
            await _carClassRepository.Save(car);
            serviceResponse.Data = _carClassMapper.MapToGetCarClassDto(await _carClassRepository.GetById(car.ID));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarClassDto>>> DeleteById(string id)
         {
             var carsWithBrand = await _carRepository.FilterBy(c => c.CarClass.ID == id);
             if (carsWithBrand.Count == 0)
             {
                 await _carClassRepository.DeleteById(id);
                 var serviceResponse = new ServiceResponse<List<GetCarClassDto>>();
                 var cars = await _carClassRepository.GetAll();
                 serviceResponse.Data = _carClassMapper.MapToGetCarClassList(cars);
                 return serviceResponse;
             }
             else
             {
                 throw new NotDeletableException();
            }
        }
    }
}
