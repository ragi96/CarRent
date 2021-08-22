using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application
{
    public class CarServiceMapper : ICarServiceMapper
    {
        private readonly BrandServiceMapper _brandServiceMapper;

        public CarServiceMapper()
        {
            _brandServiceMapper = new BrandServiceMapper();
        }
        public GetCarDto MapToGetCarDto(Car car)
        {
            var brand = car.Brand.ToEntityAsync().Result;
            return new GetCarDto
            {
                Id = car.ID,
                Name = car.Name,
                BrandDto = _brandServiceMapper.MapToGetBrandDto(brand)
            };
        }

        public List<GetCarDto> MapToGetCarDtoList(List<Car> carsList)
        {
            var getCarDtoList = new List<GetCarDto>();
            foreach (var car in carsList)
            {
                getCarDtoList.Add(MapToGetCarDto(car));
            }

            return getCarDtoList;
        }
    }
}
