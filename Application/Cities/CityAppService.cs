using ApplicationContract.City;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities
{
    public class CityAppService : ICityAppService
    {
        private readonly ICityRepo _cityRepo;

        public CityAppService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<CreateCityDto> Create(string name,int countryId, int population)
        {
            var cityDto = new CreateCityDto {
                Name = name,
                Population = population
            };

            await _cityRepo.Create(name, countryId, population);
            return cityDto;
        }
        public async Task<CreateCityDto> Update(int cityId, string name,int countryId, int population)
        {
            var updatedCity = await _cityRepo.Update(cityId, name, countryId, population); 

            var cityDto = new CreateCityDto
            {
                Name = updatedCity.Name,
                Population = updatedCity.Population
            };

            return cityDto;
        }
        public async Task<CreateCityDto> Delete(int cityId)
        {
            var deletedCity = await _cityRepo.Delete(cityId);

            var cityDto = new CreateCityDto
            {
                Name = deletedCity.Name,
                Population = deletedCity.Population
            };

            return cityDto;
        }

        public async Task<IEnumerable<GetCityDto>> GetAllCities()
        {
            var cities = await _cityRepo.GetAll();

            var cityDtos = new List<GetCityDto>();
            foreach (var city in cities)
            {
                cityDtos.Add(new GetCityDto
                {
                    CityId = city.CityId,
                    Name = city.Name,
                    countryId = city.CountryId,
                    Population = city.Population
                });
            }

            return cityDtos;
        }

        public async Task<CreateCityDto> GetCityById(int cityId)
        {
            var city = await _cityRepo.GetById(cityId);

            var cityDto = new CreateCityDto
            {
                Name = city.Name,
                Population = city.Population
            };

            return cityDto;
        }


    }
}
