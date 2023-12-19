using ApplicationContract.City;
using ApplicationContract.Countries;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Countries
{
    public class CountryAppService : ICountryAppService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryAppService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<CountryDto> Create(string Name, List<CreateCityDto> cities)
        {
            var mapedCities = cities.Select(c => new City  // Mapping cities from createCityDto to List<City> 
            {
                Name = c.Name,
                Population = c.Population,
            }).ToList();

            var data = await _countryRepo.Create(Name, mapedCities);

            return new CountryDto{
                CountryId = data.CountryId,
                Name = data.Name
            };
        }
        public async Task<CountryDto> Update(int CountryId, string Name, List<CityDto> cities)
        {
            var existingCountry = await _countryRepo.GetById(CountryId); // Fetch the existing country record from the repository

            if (existingCountry == null)
            {
                throw new Exception("Country not found"); // Custom exception handling for a non-existing country
            }

            // Update the country name
            existingCountry.Name = Name;

            // Mapping cities from CityDto to List<City>
            var mappedCities = cities.Select(c => new City
            {
                Name = c.Name,
                Population = c.Population,
            }).ToList();

            // Update existing cities or add new ones
            existingCountry.Cities = mappedCities;

            var updatedCountry = await _countryRepo.Update(existingCountry.CountryId,existingCountry.Name,existingCountry.Cities); // Call repository method to update the country

            // Map the updated country to DTO for response
            var updatedCountryDto = new CountryDto
            {
                CountryId = updatedCountry.CountryId,
                Name = updatedCountry.Name
            };

            return updatedCountryDto;
        }

        public async Task<CountryDto> Delete(int CountryId)
        {
            var country = await _countryRepo.GetById(CountryId);

            if (country == null)
            {
                throw new Exception("Country not found");
            }

            await _countryRepo.Delete(CountryId);

            var deletedCountryDto = new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };

            return deletedCountryDto;
        }

        public async Task<CountryDto> Get(string Name)
        {
            var country = await _countryRepo.Get(Name);

            if (country == null)
            {
                throw new Exception("Country not found");
            }

            var countryDto = new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };

            return countryDto;
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            var countries = await _countryRepo.GetAll();
            var countryDtos = countries.Select(country => new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            }).ToList();

            return countryDtos;
        }

        public async Task<CountryDto> GetById(int CountryId)
        {
            var country = await _countryRepo.GetById(CountryId);

            if (country == null)
            {
                throw new Exception("Country not found");
            }

            var countryDto = new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };

            return countryDto;
        }



    }
}
