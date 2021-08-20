using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using MongoDB.Bson;

namespace CarRent.CarManagment.Application
{
    public class BrandService : IBrandService
    {
        private readonly IMongoRepository<Brand> _brandRepository;

        private readonly IMapper _mapper;

        public BrandService(IMongoRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetBrandDto>> AddBrand(AddBrandDto brandDto)
        {
            var serviceResponse = new ServiceResponse<GetBrandDto>();
            await _brandRepository.InsertOneAsync(_mapper.Map<Brand>(brandDto));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBrandDto>> FindOneById(string id)
        {
            ServiceResponse<GetBrandDto> serviceResponse = new ServiceResponse<GetBrandDto>(); 
            var tBrand = await _brandRepository.FindByIdAsync(id);
            serviceResponse.Data = _mapper.Map<GetBrandDto>(tBrand);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBrandDto>>> FindAll()
        {
            ServiceResponse<IEnumerable<GetBrandDto>> serviceResponse = new ServiceResponse<IEnumerable<GetBrandDto>>();
            serviceResponse.Data = _brandRepository.FilterBy(_ => true).AsQueryable().ProjectTo<GetBrandDto>(_mapper.ConfigurationProvider).AsEnumerable<GetBrandDto>();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBrandDto>> Update(GetBrandDto brandDto)
        {
            ServiceResponse<GetBrandDto> serviceResponse = new ServiceResponse<GetBrandDto>();
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.ReplaceOneAsync(brand);
            serviceResponse.Data = _mapper.Map<GetBrandDto>(_brandRepository.FindByIdAsync(brand.Id.ToString()).Result);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBrandDto>>> DeleteById(string id)
        {
            await _brandRepository.DeleteByIdAsync(id);
            ServiceResponse<IEnumerable<GetBrandDto>> serviceResponse = new ServiceResponse<IEnumerable<GetBrandDto>>();
            serviceResponse.Data = _brandRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<GetBrandDto>(_mapper.ConfigurationProvider).AsEnumerable<GetBrandDto>();
            return serviceResponse;
        }
    }
}
