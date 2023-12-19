using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface ICityRepo
    {
        public Task<City> Create(string Name, int CountryId, int Population);
        public Task<City> Update(int CityId, string Name, int CountryId, int Population);
        public Task<City> Delete(int CityId);
        public Task<City> GetById(int CityId);
        public Task<City> Get(string Name);
        public Task<IEnumerable<City>> GetAll();    
    }
}
