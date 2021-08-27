using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    [ExcludeFromCodeCoverage]
    public class CarMapper : ICarMapper
    {
        private readonly BrandMapper _brandServiceMapper;
        private readonly CarClassMapper _carClassServiceMapper;

        public CarMapper()
        {
            _brandServiceMapper = new BrandMapper();
            _carClassServiceMapper = new CarClassMapper();
        }

        public GetCarDto MapToGetCarDto(Car car)
        {
            var brand = car.Brand.ToEntityAsync().Result;
            var carClass = car.CarClass.ToEntityAsync().Result;
            return new GetCarDto
            {
                Id = car.ID,
                Name = car.Name,
                ConstructionYear = car.ConstructionYear,
                BrandDto = _brandServiceMapper.MapToGetBrandDto(brand),
                CarClassDto = _carClassServiceMapper.MapToGetCarClassDto(carClass)
            };
        }

        public List<GetCarDto> MapToGetCarDtoList(List<Car> carsList)
        {
            var getCarDtoList = new List<GetCarDto>();
            foreach (var car in carsList) getCarDtoList.Add(MapToGetCarDto(car));

            return getCarDtoList;
        }
    }
}