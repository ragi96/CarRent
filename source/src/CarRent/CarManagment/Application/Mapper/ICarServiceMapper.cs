using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application.Mapper
{
    public interface ICarServiceMapper
    {
        GetCarDto MapToGetCarDto(Car car);

        List<GetCarDto> MapToGetCarDtoList(List<Car> carsList);
    }
}
