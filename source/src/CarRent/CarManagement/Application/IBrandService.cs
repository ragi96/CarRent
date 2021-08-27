using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.Common.Application;

namespace CarRent.CarManagement.Application
{
    public interface IBrandService
    {
        Task<ServiceResponse<GetBrandDto>> AddBrand(AddBrandDto brandDto);

        Task<ServiceResponse<GetBrandDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetBrandDto>>> FindAll();
        Task<ServiceResponse<GetBrandDto>> Update(GetBrandDto brandDto);
        Task<ServiceResponse<List<GetBrandDto>>> DeleteById(string id);
    }
}