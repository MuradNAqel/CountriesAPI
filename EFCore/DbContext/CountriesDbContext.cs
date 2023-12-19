using Domain.Entity;
using Domain.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Context
{
    public class CountriesDbContext : IdentityDbContext<IdentityUser, CustomRole, string>
    {//ApplicationUser
        public CountriesDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=CountriesDB;Uid=root;Pwd=P@ssw0rd;";
            var serverVersion = new MySqlServerVersion(new Version(8,0,35));
            optionsBuilder.UseMySql(connectionString,serverVersion);
        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<CustomRole> CustomRoles { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }

        //public DbSet<IdentityRole<string>> Roles { get; set; }
    }
}
