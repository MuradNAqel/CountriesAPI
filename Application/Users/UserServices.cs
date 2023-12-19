using ApplicationContract.User;
using Domain.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public class UserServices : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private RoleManager<CustomRole> _roleManager;
        public UserServices(UserManager<IdentityUser> userManager, RoleManager<CustomRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            try
            {

                var user = new IdentityUser()
                {
                    Email = userDto.Email,
                    UserName = userDto.name,
                };
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    if(_roleManager != null) 
                    {
                        if (!_roleManager.RoleExistsAsync("Admin3").Result)
                        {
                            var customRole = new CustomRole 
                            { 
                                Name = "Admin3",
                                Id = Guid.NewGuid().ToString(),
                                //NormalizedName = "admin".ToUpper(),
                                //ConcurrencyStamp = "fgf"
                            };
                            var RM = await _roleManager.CreateAsync(customRole);


                        }
                        //if (await roleManager.RoleExistsAsync("Admin"))
                        //{
                        //    var identityResult = await _userManager.AddToRoleAsync(user, "Admin");
                        //}
                        await _userManager.AddToRoleAsync(user, "Admin");
                        userDto.Id = user.Id;
                        return userDto;
                    }
                    else
                    {
                        string error = " ";
                        foreach (var e in result.Errors)
                        {
                            error += e.Description + ",";
                        }

                        throw new NullReferenceException(error);
                    }

                }

                else
                {
                    string error = " ";
                    foreach (var e in result.Errors)
                    {
                        error += e.Description + ",";
                    }

                    throw new NullReferenceException(error);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<UserDto> Delete(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Update(int userID, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
