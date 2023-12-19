using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContract.User
{
    public interface IUserService
    {
        public Task<UserDto> Create(UserDto userDto);
        public Task<UserDto> Update(int userID, UserDto userDto);
        public Task<UserDto> Delete(int userID);
    }
}
