using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;

namespace CarRent.CarManagment.Application
{
    public class BrandServiceMapper : IBrandServiceMapper
    {
        public GetBrandDto MapToGetBrandDto(Brand brand)
        {
            return new GetBrandDto
            {
                Id = brand.ID,
                Name = brand.Name
            };
        }

        public List<GetBrandDto> MapToGetBrandDtoList(List<Brand> brandsList)
        {
            var getBrandDtoList = new List<GetBrandDto>();
            foreach (var brand in brandsList)
            {
                getBrandDtoList.Add(MapToGetBrandDto(brand));
            }

            return getBrandDtoList;
        }
    }
}
