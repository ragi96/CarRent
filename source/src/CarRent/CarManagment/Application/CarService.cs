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

        public async Task<ServiceResponse<GetCarDTO>> AddCar(AddCarDTO car)
        {
            ServiceResponse<GetCarDTO> serviceResponse = new ServiceResponse<GetCarDTO>();
            await _carRepository.InsertOneAsync(_mapper.Map<Car>(car));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDTO>> FindOneById(string id)
        {
            ServiceResponse<GetCarDTO> serviceResponse = new ServiceResponse<GetCarDTO>();
            serviceResponse.Data = _mapper.Map<GetCarDTO>(_carRepository.FindByIdAsync(id).Result);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCarDTO>>> FindAll()
        {
            ServiceResponse<IEnumerable<GetCarDTO>> serviceResponse = new ServiceResponse<IEnumerable<GetCarDTO>>();
            serviceResponse.Data = _carRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<GetCarDTO>(_mapper.ConfigurationProvider).AsEnumerable<GetCarDTO>();
            return serviceResponse;
        }
    }
}
