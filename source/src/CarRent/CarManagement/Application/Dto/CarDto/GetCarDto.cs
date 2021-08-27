using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Application.Dto.CarClassDto;

namespace CarRent.CarManagement.Application.Dto.CarDto
{
    public class GetCarDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public GetBrandDto BrandDto { get; set; }

        public GetCarClassDto CarClassDto { get; set; }
    }
}