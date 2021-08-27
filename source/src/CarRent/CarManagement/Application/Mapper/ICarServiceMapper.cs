using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public interface ICarServiceMapper
    {
        GetCarDto MapToGetCarDto(Car car);

        List<GetCarDto> MapToGetCarDtoList(List<Car> carsList);
    }
}