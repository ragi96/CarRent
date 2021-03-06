using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Common.Application;
using CarRent.Common.Application.Dto;
using CarRent.Common.Infrastructure;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.CustomerManagement.Domain;

namespace CarRent.CustomerManagement.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerMapper _customerMapper;
        private readonly IMongoRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IMongoRepository<Customer> customerRepository, ICustomerMapper customerMapper,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCustomerDto>> Add(AddCustomerDto customerDto)
        {
            var serviceResponse = new ServiceResponse<GetCustomerDto>();
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.Save(customer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> FindOneById(string id)
        {
            var serviceResponse = new ServiceResponse<GetCustomerDto>();
            var customer = await _customerRepository.GetById(id);
            serviceResponse.Data = _customerMapper.MapToGetDto(customer);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCustomerDto>>();
            var customers = await _customerRepository.GetAll();
            serviceResponse.Data = _customerMapper.MapToGetDtoList(customers);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCustomerDto>> Update(GetCustomerDto customerDto)
        {
            var serviceResponse = new ServiceResponse<GetCustomerDto>();
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.Save(customer);
            serviceResponse.Data = _customerMapper.MapToGetDto(await _customerRepository.GetById(customer.ID));
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCustomerDto>>> Search(FuzzySearchTerm searchTerm)
        {
            var serviceResponse = new ServiceResponse<List<GetCustomerDto>>();
            var customers = await _customerRepository.FuzzySearch(searchTerm.Term);
            serviceResponse.Data = _customerMapper.MapToGetDtoList(customers);
            return serviceResponse;
        }
    }
}