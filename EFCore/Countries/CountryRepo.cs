using Domain.Entity;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Countries
{
    public class CountryRepo : ICountryRepo
    {
        private readonly CountriesDbContext _context;

        public CountryRepo(CountriesDbContext context)
        {
            _context = context;
        }

        public async Task<Country> Create(string Name, List<City> cities)
        {
            var country = new Country
            {
                Name = Name,
                Cities = cities
            };

            await _context.Countries.AddAsync(country);
         
            await _context.SaveChangesAsync();

            return country;
            
        }
        public async Task<Country> Update(int CountryId, string Name, List<City> cities)
        {
            Country country = await _context.Countries.FindAsync(CountryId);

            if (country == null)
            {
                throw new Exception("Country not found");
            }

            country.Name = Name;
            country.Cities = cities;

            _context.Countries.Update(country);

            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<Country> Delete(int CountryId)
        {
            var country = await GetById(CountryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return await GetById(CountryId);
            }
            return new Country { Name = "country not found" };
        }

        public async Task<Country> Get(string Name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == Name) ?? throw new Exception("Country not found");
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetById(int CountryId)
        {
            return await _context.Countries.FindAsync(CountryId) ?? throw new Exception("Country not found");
        }


    }
}
