using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface ICountryRepo
    {
        public Task<Country> Create(string Name, List<City> cities);
        public Task<Country> Update(int CountryId, string Name, List<City> cities);
        public Task<Country> Delete(int CountryId);
        public Task<Country> GetById(int CountryId);
        public Task<Country> Get(string Name);
        public Task<IEnumerable<Country>> GetAll();
    }
}
