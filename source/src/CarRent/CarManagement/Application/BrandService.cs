using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.CarManagement.Application.Mapper;
using CarRent.CarManagement.Domain;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;

namespace CarRent.CarManagement.Application
{
    public class BrandService : IBrandService
    {
        private readonly IBrandServiceMapper _brandMapper;
        private readonly IMongoRepository<Brand> _brandRepository;

        private readonly IMongoRepository<Car> _carRepository;

        private readonly IMapper _mapper;

        public BrandService(IMongoRepository<Brand> brandRepository, IBrandServiceMapper brandMapper,
            IMongoRepository<Car> carRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _carRepository = carRepository;
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
            var serviceResponse = new ServiceResponse<GetBrandDto>();
            var tBrand = await _brandRepository.GetById(id);
            serviceResponse.Data = _brandMapper.MapToGetBrandDto(tBrand);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBrandDto>>> FindAll()
        {
            var serviceResponse = new ServiceResponse<List<GetBrandDto>>();
            var brands = await _brandRepository.GetAll();
            serviceResponse.Data = _brandMapper.MapToGetBrandDtoList(brands);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBrandDto>> Update(GetBrandDto brandDto)
        {
            var serviceResponse = new ServiceResponse<GetBrandDto>();
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.Save(brand);
            serviceResponse.Data = _brandMapper.MapToGetBrandDto(await _brandRepository.GetById(brand.ID));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBrandDto>>> DeleteById(string id)
        {
            var carsWithBrand = await _carRepository.FilterBy(c => c.Brand.ID == id);
            if (carsWithBrand.Count == 0)
            {
                await _brandRepository.DeleteById(id);
                var serviceResponse = new ServiceResponse<List<GetBrandDto>>();
                var brands = await _brandRepository.GetAll();
                serviceResponse.Data = _brandMapper.MapToGetBrandDtoList(brands);
                return serviceResponse;
            }

            throw new NotDeletableException();
        }
    }
}