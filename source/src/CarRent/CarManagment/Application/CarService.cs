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

        public async Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto car)
        {
            ServiceResponse<GetCarDto> serviceResponse = new ServiceResponse<GetCarDto>();
            await _carRepository.InsertOneAsync(_mapper.Map<Car>(car));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> FindOneById(string id)
        {
            ServiceResponse<GetCarDto> serviceResponse = new ServiceResponse<GetCarDto>();
            serviceResponse.Data = _mapper.Map<GetCarDto>(_carRepository.FindByIdAsync(id).Result);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCarDto>>> FindAll()
        {
            ServiceResponse<IEnumerable<GetCarDto>> serviceResponse = new ServiceResponse<IEnumerable<GetCarDto>>();
            serviceResponse.Data = _carRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<GetCarDto>(_mapper.ConfigurationProvider).AsEnumerable<GetCarDto>();
            return serviceResponse;
        }
    }
}
