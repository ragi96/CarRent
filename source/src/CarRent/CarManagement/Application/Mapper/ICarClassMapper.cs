using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public interface ICarClassMapper
    {
        GetCarClassDto MapToGetCarClassDto(CarClass carClass);

        List<GetCarClassDto> MapToGetCarClassDtoList(List<CarClass> carClassesList);
    }
}