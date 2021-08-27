using System.Collections.Generic;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Domain;

namespace CarRent.CustomerManagement.Application.Mapper
{
    public interface ICustomerMapper
    {
        GetCustomerDto MapToGetDto(Customer customer);

        List<GetCustomerDto> MapToGetDtoList(List<Customer> customerList);
    }
}