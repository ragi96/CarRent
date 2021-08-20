using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagment.Application
{
    public interface IBrandService
    {
        Task<ServiceResponse<GetBrandDto>> AddBrand(AddBrandDto branDto);

        Task<ServiceResponse<GetBrandDto>> FindOneById(string id);

        Task<ServiceResponse<IEnumerable<GetBrandDto>>> FindAll();
        Task<ServiceResponse<GetBrandDto>> Update(GetBrandDto brandDto);
        Task<ServiceResponse<IEnumerable<GetBrandDto>>> DeleteById(string id);
    }
}
