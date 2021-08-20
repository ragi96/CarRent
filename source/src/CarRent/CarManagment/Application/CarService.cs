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
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using MongoDB.Bson;

namespace CarRent.CarManagment.Application
{
    public class CarService : ICarService
    {
        private readonly IMongoRepository<Car> _carRepository;

        private readonly IMapper _mapper;

        public CarService(IMongoRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CarDto>> AddCar(CarDto carDto)
        {
            ServiceResponse<CarDto> serviceResponse = new ServiceResponse<CarDto>();
            await _carRepository.InsertOneAsync(_mapper.Map<Car>(carDto));
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarDto>> FindOneById(string id)
        {
            ServiceResponse<CarDto> serviceResponse = new ServiceResponse<CarDto>(); 
            var tCar = await _carRepository.FindByIdAsync(id);
            serviceResponse.Data = _mapper.Map<CarDto>(tCar);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarDto>>> FindAll()
        {
            ServiceResponse<IEnumerable<CarDto>> serviceResponse = new ServiceResponse<IEnumerable<CarDto>>();
            serviceResponse.Data = _carRepository.FilterBy(_ => true).AsQueryable().ProjectTo<CarDto>(_mapper.ConfigurationProvider).AsEnumerable<CarDto>();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarDto>> Update(CarDto carDto)
        {
            ServiceResponse<CarDto> serviceResponse = new ServiceResponse<CarDto>();
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.ReplaceOneAsync(car);
            serviceResponse.Data = _mapper.Map<CarDto>(_carRepository.FindByIdAsync(car.Id.ToString()).Result);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CarDto>>> DeleteById(string id)
        {
            await _carRepository.DeleteByIdAsync(id);
            ServiceResponse<IEnumerable<CarDto>> serviceResponse = new ServiceResponse<IEnumerable<CarDto>>();
            serviceResponse.Data = _carRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<CarDto>(_mapper.ConfigurationProvider).AsEnumerable<CarDto>();
            return serviceResponse;
        }
    }
}
