using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application.Mapper
{
    public interface ICarClassServiceMapper
    {
        GetCarClassDto MapToGetCarClassDto(CarClass carClass);

        List<GetCarClassDto> MapToGetCarClassList(List<CarClass> carClassesList);
    }
}
