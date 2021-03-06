using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.CarClassDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public class CarClassMapper : ICarClassMapper
    {
        public GetCarClassDto MapToGetCarClassDto(CarClass carClass)
        {
            return new()
            {
                Id = carClass.ID,
                Name = carClass.Name,
                DailyPrice = carClass.DailyPrice
            };
        }

        public List<GetCarClassDto> MapToGetCarClassDtoList(List<CarClass> carClassesList)
        {
            var getCarClassesDtoList = new List<GetCarClassDto>();
            foreach (var carClass in carClassesList) getCarClassesDtoList.Add(MapToGetCarClassDto(carClass));

            return getCarClassesDtoList;
        }
    }
}