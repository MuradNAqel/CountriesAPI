using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.City
{
    public class GetCityDto
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int countryId { get; set; }
        public int CityId { get; set; }
    }
}
