using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.City
{
    public interface ICityAppService
    {
        public Task<CreateCityDto> Create(string name,int countryId, int population);
        public Task<CreateCityDto> Update(int cityId,string name,int countryId, int population);
        public Task<CreateCityDto> Delete(int cityId);
        public Task<CreateCityDto> GetCityById(int cityId);
        public Task<IEnumerable<GetCityDto>> GetAllCities();
        
    }
}
