using ApplicationContract.City;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.Countries
{
    public class CreateCountryDto
    {
        public string Name { get; set; }
        public List<CreateCityDto> Cities { get; set; }
    }
}
