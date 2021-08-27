﻿using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public class CarServiceMapper : ICarServiceMapper
    {
        private readonly BrandServiceMapper _brandServiceMapper;
        private readonly CarClassServiceMapper _carClassServiceMapper;

        public CarServiceMapper()
        {
            _brandServiceMapper = new BrandServiceMapper();
            _carClassServiceMapper = new CarClassServiceMapper();
        }

        public GetCarDto MapToGetCarDto(Car car)
        {
            var brand = car.Brand.ToEntityAsync().Result;
            var carClass = car.CarClass.ToEntityAsync().Result;
            return new GetCarDto
            {
                Id = car.ID,
                Name = car.Name,
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