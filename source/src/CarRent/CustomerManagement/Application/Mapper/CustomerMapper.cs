using System.Collections.Generic;
using CarRent.CustomerManagement.Application.Dto.CarDto;
using CarRent.CustomerManagement.Domain;

namespace CarRent.CustomerManagement.Application.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        public GetCustomerDto MapToGetDto(Customer customer)
        {
            return new()
            {
                Id = customer.ID,
            };
        }

        public List<GetCustomerDto> MapToGetDtoList(List<Customer> customerList)
        {
            var getDtoList = new List<GetCustomerDto>();
            foreach (var customer in customerList) getDtoList.Add(MapToGetDto(customer));

            return getDtoList;
        }
    }
}