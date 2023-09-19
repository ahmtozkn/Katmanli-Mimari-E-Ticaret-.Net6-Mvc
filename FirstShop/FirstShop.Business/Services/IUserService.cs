using FirstShop.Business.Dtos;
using FirstShop.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
   public interface IUserService
    {

        ServiceMessage AddUser(AddUserDto addUserDto);

        UserInfoDto LoginUser(LoginUserDto loginUserDto);

        UserInfoDto GetById(int id);
        List<UserInfoDto> GetUsers();
        
        bool ChangePassword(UserPasswordDto userPasswordDto);

        void EditUser(EditUserDto editUserDto);
    }
}
