using System.Collections.Generic;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Application.Mapper
{
    public class BrandMapper : IBrandMapper
    {
        public GetBrandDto MapToGetBrandDto(Brand brand)
        {
            return new()
            {
                Id = brand.ID,
                Name = brand.Name
            };
        }

        public List<GetBrandDto> MapToGetBrandDtoList(List<Brand> brandsList)
        {
            var getBrandDtoList = new List<GetBrandDto>();
            foreach (var brand in brandsList) getBrandDtoList.Add(MapToGetBrandDto(brand));

            return getBrandDtoList;
        }
    }
}