using ApplicationContract.City;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.Countries
{
    public interface ICountryAppService
    {
        public Task<CountryDto> Create(string Name, List<CreateCityDto> cities);
        public Task<CountryDto> Update(int CountryId, string Name, List<CityDto> cities);
        public Task<CountryDto> Delete(int CountryId);
        public Task<CountryDto> GetById(int CountryId);
        public Task<CountryDto> Get(string Name);
        public Task<IEnumerable<CountryDto>> GetAll();

    }
}
