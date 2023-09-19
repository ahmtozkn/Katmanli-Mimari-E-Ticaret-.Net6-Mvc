using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Areas.Admin.Controllers
{       
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {

       

        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;

        }
        public IActionResult Index()
        {
            var Orders = _orderService.GetOrders().ToList();
            var viewModel = Orders.OrderByDescending(X => X.CreatedDate).Select(x => new ListOrderViewModel()
            {
                Id = x.Id,
                UserId = x.UserId,
                OrderStatus = x.OrderStatus,
                CreatedDate = x.CreatedDate,
                UserName = x.UserName,
                Adres = x.Address,



            }).ToList();




            return View(viewModel);
        }


        public IActionResult Statu(int id)
        {
            var Order = _orderService.GetOrder(id);
            var editDto = new GetOrderDto()
            {
                Id = Order.Id,
                UserId = Order.UserId,
                OrderStatus = Data.Enums.OrderStatusEnum.TeslimEdildi,
                CreatedDate = Order.CreatedDate,
                AddressId = Order.AddressId,
                PaymentMethodId = Order.PaymentMethodId,

            };

            _orderService.EditOrder(editDto);


            return RedirectToAction("Index", "Order");
        }
    }
}
