using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public interface IBrandServiceMapper
    {
        GetBrandDto MapToGetBrandDto(Brand brand);

        List<GetBrandDto> MapToGetBrandDtoList(List<Brand> brandsList);
    }
}