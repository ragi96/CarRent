using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application.Mapper
{
    public interface IBrandServiceMapper
    {
        GetBrandDto MapToGetBrandDto(Brand brand);

        List<GetBrandDto> MapToGetBrandDtoList(List<Brand> brandsList);
    }
}
