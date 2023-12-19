using ApplicationContract.City;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.Countries
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<CityDto> Cities { get; set; } 

    }
}
