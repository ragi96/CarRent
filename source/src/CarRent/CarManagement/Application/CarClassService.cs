using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagement.Application
{
    public class CarClassService : ICarClassService
    {
        private readonly ICarClassMapper _carClassMapper;
        private readonly IMongoRepository<CarClass> _carClassRepository;
        private readonly IMongoRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarClassService(IMongoRepository<CarClass> carClassRepository, IMongoRepository<Car> carRepository,
            ICarClassMapper carClassMapper, IMapper mapper)
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
            var carClass = await _carClassRepository.GetById(id);
            if (carClass != null)
            {
                serviceResponse.Data = _carClassMapper.MapToGetCarClassDto(carClass);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Can't be found";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCarClassDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCarClassDto>>();
            var carClasses = await _carClassRepository.GetAll();
            serviceResponse.Data = _carClassMapper.MapToGetCarClassDtoList(carClasses);
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
            var serviceResponse = new ServiceResponse<List<GetCarClassDto>>();
            if (carsWithBrand.Count == 0)
            {
                await _carClassRepository.DeleteById(id);
                var cars = await _carClassRepository.GetAll();
                serviceResponse.Data = _carClassMapper.MapToGetCarClassDtoList(cars);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Can't be deleted";
            }

            return serviceResponse;
        }
    }
}