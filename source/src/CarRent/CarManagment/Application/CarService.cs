using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagment.Domain;
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

        public async Task AddCar(CarDTO car)
        {
            await _carRepository.InsertOneAsync(_mapper.Map<Car>(car));
        }

        public CarDTO FindOneById(string id)
        {
            return _mapper.Map<CarDTO>(_carRepository.FindById(id));
        }
    }
}
