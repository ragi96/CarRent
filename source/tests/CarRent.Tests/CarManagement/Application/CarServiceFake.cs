using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using MongoDB.Bson;

namespace CarRent.Tests.CarManagement.Application
{
    class CarServiceFake : ICarService
    {
        private readonly List<GetCarDto> _car;
        public CarServiceFake()
        {
            _car = new List<GetCarDto>()
            {
                new GetCarDto() {Id = "asdasdasdasdasd1", Name = "Fiat 500"},
                new GetCarDto() {Id = "asdasdasdasdasd2", Name = "Ferrari F50"},
                new GetCarDto() {Id = "asdasdasdasdasd3", Name = "Lamborghini Urus"},
                new GetCarDto() {Id = "asdasdasdasdasd4", Name = "Koenigsegg All"},
                new GetCarDto() {Id = "asdasdasdasdasd5", Name = "Fiat Panda"},
                new GetCarDto() {Id = "asdasdasdasdasd6", Name = "Smart"},
                new GetCarDto() {Id = "asdasdasdasdasd7", Name = "Jeep Wrangler"},
            };
        }

        public Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto carDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCarDto>> FindOneById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<GetCarDto>>> FindAll()
        {
            ServiceResponse<IEnumerable<GetCarDto>> serviceResponse = new ServiceResponse<IEnumerable<GetCarDto>>();
            serviceResponse.Data = _car.AsEnumerable<GetCarDto>();
            return Task<ServiceResponse<IEnumerable<GetCarDto>>>.FromResult(serviceResponse);

        }
        public Task<ServiceResponse<GetCarDto>> Update(GetCarDto carDto)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<IEnumerable<GetCarDto>>> DeleteById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
