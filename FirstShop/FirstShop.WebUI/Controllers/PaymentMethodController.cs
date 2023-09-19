using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Data.Entities;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public IActionResult Add(int? AddressId)
        {
             
            ViewBag.AddressId = AddressId;  
            var userId=User.GetUserId();

            var paymentListDto=_paymentMethodService.GetAllPaymentMethods();
            var paymentListViewModel=paymentListDto.Where(x=>x.UserId==userId && x.PaymentMethodName==Data.Enums.PaymentMethodEnum.Kart).Select(x=> new PaymentListViewModel() 
            { 
                Id=x.Id,
                CardNumber=x.CardNumber,
                
                
            
            
            }).ToList();
            ViewBag.PaymentList=paymentListViewModel;

            return View();
        }
        [HttpPost]
        public IActionResult Add(PaymentMethodViewModel paymentMethodViewModel)
        {
            
            if (paymentMethodViewModel.PaymentMethodName == Data.Enums.PaymentMethodEnum.Pesin)
            { 
             var paymentMethodDto = _paymentMethodService.GetAllPaymentMethods().FirstOrDefault(x=>x.PaymentMethodName==paymentMethodViewModel.PaymentMethodName&&x.UserId==paymentMethodViewModel.UserId);
            if(paymentMethodDto is not null)
            {
                return RedirectToAction("Add", "Order", new {addressId = paymentMethodViewModel.AddressId, paymentMethodId = paymentMethodDto.Id  });
            }

            }

           

            if (paymentMethodViewModel.PaymentMethodName == Data.Enums.PaymentMethodEnum.Pesin)
            {
                var addPaymentMethodDto = new AddPaymentMethodDto()
                {
                    UserId= paymentMethodViewModel.UserId,
                    CardNumber="1",
                    CVV=1,
                    ExpirationMonth =null,
                    ExpirationYear=null,
                    PaymentMethodName=paymentMethodViewModel.PaymentMethodName,
                    
                    

                };
               
                var paymentId =_paymentMethodService.AddPaymentMethod(addPaymentMethodDto);

                return RedirectToAction("Add", "Order", new { addressId = paymentMethodViewModel.AddressId, paymentMethodId =paymentId });




            }


            var addPayementDto = new AddPaymentMethodDto()
            {
                CardNumber = paymentMethodViewModel.CardNumber,
                CVV = paymentMethodViewModel.CVV,
                ExpirationMonth = paymentMethodViewModel.ExpirationMonth,
                ExpirationYear = paymentMethodViewModel.ExpirationYear,
                PaymentMethodName = paymentMethodViewModel.PaymentMethodName,
                UserId = paymentMethodViewModel.UserId
            };

            var paymentMethodId = _paymentMethodService.AddPaymentMethod(addPayementDto);


            return RedirectToAction("Add", "Order", new { addressId=paymentMethodViewModel.AddressId, paymentMethodId=paymentMethodId} );
               


        }

    }
}
