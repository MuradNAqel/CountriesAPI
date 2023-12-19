using Domain.Entity;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Cities
{
    public class CityRepo : ICityRepo
    {
        private readonly CountriesDbContext _context;

        public CityRepo(CountriesDbContext context)
        {
            _context = context;
        }

        public async Task<City> Create(string Name, int CountryId, int Population)
        {
            var city = new City { 
                Name = Name, 
                CountryId = CountryId, 
                Population = Population,
            };

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<City> Update(int CityId, string Name, int CountryId, int Population)
        {
            var city = await _context.Cities.FindAsync(CityId);

            if (city == null) 
            {
                throw new Exception("City not found");
            }
            city.Population = Population;
            city.Name = Name;
            city.CountryId = CountryId;

            _context.Cities.Update(city);

            await _context.SaveChangesAsync();
            return city;

        }

        public async Task<City> Delete(int CityId)
        {
            var city = await GetById(CityId);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
                return new City { };
            }
            return new City { Name = "country not found" };
        }

        public async Task<City> Get(string Name)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Name == Name) ?? throw new Exception("Country not found");
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetById(int CityId)
        {
            return await _context.Cities.FindAsync(CityId) ?? throw new Exception("Country not found");
        }


    }
}
