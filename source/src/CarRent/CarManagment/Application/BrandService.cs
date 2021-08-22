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
using CarRent.CarManagment.Application.Mapper;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using MongoDB.Bson;

namespace CarRent.CarManagment.Application
{
    public class BrandService : IBrandService
    {
        private readonly IMongoRepository<Brand> _brandRepository;

        private readonly IBrandServiceMapper _brandMapper;

        private readonly IMapper _mapper;

        public BrandService(IMongoRepository<Brand> brandRepository, IBrandServiceMapper brandMapper, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandMapper = brandMapper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetBrandDto>> AddBrand(AddBrandDto brandDto)
        {
            var serviceResponse = new ServiceResponse<GetBrandDto>();
            await _brandRepository.Save(_mapper.Map<Brand>(brandDto));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBrandDto>> FindOneById(string id)
        {
            ServiceResponse<GetBrandDto> serviceResponse = new ServiceResponse<GetBrandDto>(); 
            var tBrand = await _brandRepository.GetById(id);
            serviceResponse.Data = _brandMapper.MapToGetBrandDto(tBrand);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBrandDto>>> FindAll()
        {
            ServiceResponse<List<GetBrandDto>> serviceResponse = new ServiceResponse<List<GetBrandDto>>();
            var brands = await _brandRepository.GetAll();
            serviceResponse.Data = _brandMapper.MapToGetBrandDtoList(brands);
            return serviceResponse;
        }

       public async Task<ServiceResponse<GetBrandDto>> Update(GetBrandDto brandDto)
       {
            ServiceResponse<GetBrandDto> serviceResponse = new ServiceResponse<GetBrandDto>();
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.Save(brand);
            serviceResponse.Data = _mapper.Map<GetBrandDto>(await _brandRepository.GetById(brand.ID));
            return serviceResponse;
        }

           /*      public async Task<ServiceResponse<IEnumerable<GetBrandDto>>> DeleteById(string id)
               {
                  await _brandRepository.DeleteByIdAsync(id);
                   ServiceResponse<IEnumerable<GetBrandDto>> serviceResponse = new ServiceResponse<IEnumerable<GetBrandDto>>();
                   serviceResponse.Data = _brandRepository.FilterBy(c => c.Name != "").AsQueryable().ProjectTo<GetBrandDto>(_mapper.ConfigurationProvider).AsEnumerable<GetBrandDto>();
                   return serviceResponse;
            }*/
    }
}
