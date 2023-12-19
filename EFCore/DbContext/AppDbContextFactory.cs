using EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<CountriesDbContext>
    {
        public CountriesDbContext CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<CountriesDbContext>();
            var connectionString = "Server=localhost;Database=CountriesDB;Uid=root;Pwd=P@ssw0rd;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

            option.UseMySql(connectionString, serverVersion);
            return new CountriesDbContext(option.Options);  
        }
    }
}
