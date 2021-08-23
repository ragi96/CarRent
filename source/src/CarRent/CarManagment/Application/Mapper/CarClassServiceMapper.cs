using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application
{
    public class CarClassServiceMapper : ICarClassServiceMapper
    {
        public GetCarClassDto MapToGetCarClassDto(CarClass carClass)
        {
            return new GetCarClassDto
            {
                Id = carClass.ID,
                Name = carClass.Name,
                DailyPrice = carClass.DailyPrice
            };
        }

        public List<GetCarClassDto> MapToGetCarClassList(List<CarClass> carClassesList)
        {
            var getCarClassesDtoList = new List<GetCarClassDto>();
            foreach (var carClass in carClassesList)
            {
                getCarClassesDtoList.Add(MapToGetCarClassDto(carClass));
            }

            return getCarClassesDtoList;
        }
    }
}
