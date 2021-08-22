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
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using MongoDB.Bson;

namespace CarRent.CarManagment.Application
{
    public class CarService : ICarService
    {
        private readonly IMongoRepository<Car> _carRepository;
        private readonly IMongoRepository<Brand> _brandRepository;

        private readonly ICarServiceMapper _carMapper;
        private readonly IMapper _mapper;

        public CarService(IMongoRepository<Car> carRepository, IMongoRepository<Brand> brandRepository, ICarServiceMapper carMapper, IMapper mapper)
        {
            _carRepository = carRepository;
            _brandRepository = brandRepository;
            _carMapper = carMapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto carDto)
        {
            var serviceResponse = new ServiceResponse<GetCarDto>();
            var car = _mapper.Map<Car>(carDto);
            var brand = _brandRepository.GetById(carDto.BrandId).Result;
            car.Brand = brand;
            await _carRepository.Save(car);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> FindOneById(string id)
        {
            ServiceResponse<GetCarDto> serviceResponse = new ServiceResponse<GetCarDto>(); 
            var tCar = await _carRepository.GetById(id);
            serviceResponse.Data = _carMapper.MapToGetCarDto(tCar);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCarDto>>> FindAll()
        { 
            ServiceResponse<IEnumerable<GetCarDto>> serviceResponse = new ServiceResponse<IEnumerable<GetCarDto>>(); 
            var cars = await _carRepository.GetAll(); 
            serviceResponse.Data = _carMapper.MapToGetCarDtoList(cars); 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> Update(GetCarDto brandDto)
        {
            ServiceResponse<GetCarDto> serviceResponse = new ServiceResponse<GetCarDto>();
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.Save(brand);
            serviceResponse.Data = _carMapper.MapToGetCarDto(await _carRepository.GetById(brand.ID));
            return serviceResponse;
        }

        /*  public async Task<ServiceResponse<GetCarDto>> Update(GetCarDto carDto)
         {
             ServiceResponse<GetCarDto> serviceResponse = new ServiceResponse<GetCarDto>();
             var car = _mapper.Map<Car>(carDto);
             await _carRepository.ReplaceOneAsync(car);
             serviceResponse.Data = _mapper.Map<GetCarDto>(_carRepository.FindByIdAsync(car.ID.ToString()).Result);
             return serviceResponse;
         }

         public async Task<ServiceResponse<IEnumerable<GetCarDto>>> DeleteById(string id)
         {
             await _carRepository.DeleteByIdAsync(id);
             ServiceResponse<IEnumerable<GetCarDto>> serviceResponse = new ServiceResponse<IEnumerable<GetCarDto>>();
             serviceResponse.Data = _carRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<GetCarDto>(_mapper.ConfigurationProvider).AsEnumerable<GetCarDto>();
             return serviceResponse;
         }*/
    }
}
