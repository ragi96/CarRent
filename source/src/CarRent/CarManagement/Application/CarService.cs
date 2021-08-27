using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagement.Application
{
    public class CarService : ICarService
    {
        private readonly IMongoRepository<Brand> _brandRepository;
        private readonly IMongoRepository<CarClass> _carClassRepository;

        private readonly ICarServiceMapper _carMapper;
        private readonly IMongoRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarService(IMongoRepository<Car> carRepository, IMongoRepository<Brand> brandRepository,
            IMongoRepository<CarClass> carClassRepository, ICarServiceMapper carMapper, IMapper mapper)
        {
            _carRepository = carRepository;
            _brandRepository = brandRepository;
            _carClassRepository = carClassRepository;
            _carMapper = carMapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto carDto)
        {
            var serviceResponse = new ServiceResponse<GetCarDto>();
            var car = _mapper.Map<Car>(carDto);
            var brand = _brandRepository.GetById(carDto.BrandId).Result;
            car.Brand = brand;
            var carClass = _carClassRepository.GetById(carDto.CarClassId).Result;
            car.CarClass = carClass;
            await _carRepository.Save(car);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> FindOneById(string id)
        {
            var serviceResponse = new ServiceResponse<GetCarDto>();
            var tCar = await _carRepository.GetById(id);
            serviceResponse.Data = _carMapper.MapToGetCarDto(tCar);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCarDto>>();
            var cars = await _carRepository.GetAll();
            serviceResponse.Data = _carMapper.MapToGetCarDtoList(cars);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCarDto>> Update(UpdateCarDto carDto)
        {
            var serviceResponse = new ServiceResponse<GetCarDto>();
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.Save(car);
            serviceResponse.Data = _carMapper.MapToGetCarDto(await _carRepository.GetById(car.ID));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarDto>>> DeleteById(string id)
        {
            await _carRepository.DeleteById(id);
            var serviceResponse = new ServiceResponse<List<GetCarDto>>();
            var cars = await _carRepository.GetAll();
            serviceResponse.Data = _carMapper.MapToGetCarDtoList(cars);
            return serviceResponse;
        }
    }
}