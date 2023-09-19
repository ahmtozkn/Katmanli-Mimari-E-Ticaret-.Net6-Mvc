using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Business.Types;
using FirstShop.Data.Entities;
using FirstShop.Data.Enums;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Managers
{
    public class UserManager:IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtector _dataProtector;
        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public ServiceMessage AddUser(AddUserDto addUserDto)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == addUserDto.Email.ToLower()).ToList();
            

            if (hasMail.Any()) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu Eposta adresli bir kullanıcı zaten mevcut."
                };
            }

            var userEntity = new UserEntity()
            {
                FirstName = addUserDto.FirstName,
                LastName = addUserDto.LastName,
                Email = addUserDto.Email,
                Password = _dataProtector.Protect(addUserDto.Password),
                UserType = UserTypeEnum.User
                
            };

            _userRepository.Add(userEntity);

            return new ServiceMessage()
            {
                IsSucceed = true
            };
        }

        public bool ChangePassword(UserPasswordDto userPasswordDto)
        {
            var userEntity = _userRepository.GetById(userPasswordDto.Id);
            if(userEntity != null)
            {
                var rawPassword = _dataProtector.Unprotect(userEntity.Password);
                if(rawPassword ==userPasswordDto.CurrentPassword)
                {
                    userEntity.Password = _dataProtector.Protect(userPasswordDto.NewPassword);
                    _userRepository.Update(userEntity);
                    return true;
                }
                return false;

            }
            return false;
        }

        public void EditUser(EditUserDto editUserDto)
        {
            var userEntity =_userRepository.GetById(editUserDto.Id);
            userEntity.Email = editUserDto.Email;
            userEntity.Password = userEntity.Password;
            userEntity.LastName = editUserDto.LastName;
            userEntity.FirstName = editUserDto.FirstName;
            userEntity.UserType=userEntity.UserType;
            _userRepository.Update(userEntity);


            
        }

        public UserInfoDto GetById(int id)
        {
            var entity = _userRepository.GetById(id);
            var userInfoDto = new UserInfoDto()
            {
                Id = id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                UserType = entity.UserType,


            };
            return userInfoDto;
        }

        public List<UserInfoDto> GetUsers()
        {
            var userInfoDto = _userRepository.GetAll().Select(x => new UserInfoDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserType = x.UserType,

            }).ToList();
            return userInfoDto;
        }

        public UserInfoDto LoginUser(LoginUserDto loginUserDto)
        {
            var userEntity = _userRepository.Get(x => x.Email == loginUserDto.Email);

            if (userEntity is null)
            {
                return null;
               
            }

            var rawPassword = _dataProtector.Unprotect(userEntity.Password);

            if (loginUserDto.Password == rawPassword)
            {
                return new UserInfoDto()
                {
                    Id = userEntity.Id,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    UserType = userEntity.UserType,
                    Email = userEntity.Email
                };
            }
            else
            {
                return null;
            }




        }
    }
}
