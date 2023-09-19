using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var addressesEntity = _addressService.GetAllAddresses();
            var user = User.GetUserId();
            var userId = Convert.ToInt32(User.GetUserId());


            var viewModel = addressesEntity.Where(x => x.UserId == userId).Select(x => new AddressViewModel()
            {
                Id = x.Id,
                Adres = x.Adres
            }).ToList();
            ViewBag.Address = viewModel;


            return View();
        }

        [HttpPost]
        public IActionResult Add(AddressViewModel addressViewModel)
        {
            var user = User.GetUserId();
            var userId = Convert.ToInt32(user);
            var addAddressDto = new AddAddressDto()
            {
                Ad = User.GetUserFirstName(),
                Soyad = User.GetUserLastName(),
                Sehir = addressViewModel.Sehir,
                PostaKodu = addressViewModel.PostaKodu,
                Adres = addressViewModel.Adres,
                UserId = userId

            };
            var entityId = _addressService.AddAddress(addAddressDto);

            return RedirectToAction("Add", "PaymentMethod", new { AddressId = entityId });
        }
    }
}
