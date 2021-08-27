using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.CustomerManagement.Application.Dto;

namespace CarRent.CustomerManagement.Application
{
    public interface ICustomerService
    {
        Task<ServiceResponse<GetCustomerDto>> Add(AddCustomerDto customerDto);

        Task<ServiceResponse<GetCustomerDto>> FindOneById(string id);

        Task<ServiceResponse<List<GetCustomerDto>>> FindAll();
        Task<ServiceResponse<GetCustomerDto>> Update(GetCustomerDto customerDto);
        Task<ServiceResponse<List<GetCustomerDto>>> DeleteById(string id);
    }
}