using ApplicationContract.City;
using ApplicationContract.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.Users
{
    public interface IAuthAppServiece
    {
        Task<bool> ValidateUser(string userEmail, string userPassword);
        string CreateToken();
        Task<bool> EmailIsExist(string userEmail);
        Task<string> ConfirmEmailAsync(string userId, string token);
    }
}
