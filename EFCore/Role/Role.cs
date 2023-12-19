using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Role
{
    public class Role : IdentityRole<string>
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
