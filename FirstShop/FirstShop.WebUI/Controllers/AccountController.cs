using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstShop.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IPaymentMethodService _paymentMethodService;
        public AccountController(IUserService userService, IAddressService addressService,IPaymentMethodService paymentMethodService)
        {
            _userService = userService;
            _addressService = addressService;
            _paymentMethodService = paymentMethodService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
          var userDto= _userService.GetById(User.GetUserId());

            var profileViewModel = new ProfileViewModel()
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,

            };




            return View(profileViewModel);

        }
        [HttpGet]
        public IActionResult EditProfile() 
        {

            var editUser=_userService.GetById(User.GetUserId());
            var editProfileViewModel = new EditProfileViewModel()
            {
                Id = editUser.Id,
                Email = editUser.Email,
                FirstName = editUser.FirstName,
                LastName = editUser.LastName,

            };
         
            return View(editProfileViewModel);
        }
        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editProfileViewModel) 
        {
            

            var editDto = new EditUserDto()
            {
                Email = editProfileViewModel.Email,
                FirstName = editProfileViewModel.FirstName,
                LastName = editProfileViewModel.LastName,
                Id = editProfileViewModel.Id
            };

            _userService.EditUser(editDto);
             

            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {


            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(UserPasswordViewModel passwordViewModel)
        {
            passwordViewModel.Id= User.GetUserId();
            
            if(passwordViewModel.Password==passwordViewModel.PasswordConfirm) 
            { 


            var userPasswordDto = new UserPasswordDto()
            {
                Id = User.GetUserId(),
                CurrentPassword = passwordViewModel.CurrentPassword,
                NewPassword = passwordViewModel.Password
            };
            var result=_userService.ChangePassword(userPasswordDto);

                if (result == true)
                {

                    return Redirect("Profile");
                }
                else
                    return Redirect("ChangePassword");

       
            }

            return Redirect("ChangePassword");

        }   

       public IActionResult AddressInfo()
        {
            var userId= User.GetUserId();
            var addressEntity= _addressService.GetAllAddresses().Where(x=>x.UserId==userId);
            var addressListViewModel = addressEntity.Select(x => new AddressListViewModel()
            {
                Id = x.Id,
                Adres = x.Adres,
                Sehir = x.Sehir,
                PostaKodu = x.PostaKodu,
            }).ToList();
            return View(addressListViewModel);
        }

        public IActionResult PaymentInfo() 
        {
            var userId=User.GetUserId();
            var paymentListDto = _paymentMethodService.GetAllPaymentMethods().Where(x=>x.PaymentMethodName==Data.Enums.PaymentMethodEnum.Kart&&x.UserId == userId);
            var paymentListViewModel = paymentListDto.Select(x => new PaymentListViewModel()
            {
                CardNumber = x.CardNumber,
                ExpirationMonth = x.ExpirationMonth,
                ExpirationYear = x.ExpirationYear,
                Name = User.GetUserFirstName() + " " + User.GetUserLastName()
            }).ToList();


            return View(paymentListViewModel);

        
        
        }

    }
}
