using FirstShop.Business.Services;
using FirstShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {

        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public DashboardController(IUserService userService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _userService = userService;
            _productService = productService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            var userCount = _userService.GetUsers().Where(x => x.UserType == Data.Enums.UserTypeEnum.User).Count();
            var adminCount = _userService.GetUsers().Where(x => x.UserType == Data.Enums.UserTypeEnum.Admin).Count(); ;
            var productCount = _productService.GetProducts().Count();
            var orderCount = _orderService.GetOrders().Count();
            var orderWeekCount = _orderService.GetOrders().Where(x => (DateTime.Now - x.CreatedDate).TotalDays <= 7).Count();




            var dashboardViewModel = new DashboardViewModel()
            {
                AdminCount = adminCount,
                ProductCount = productCount,
                OrderCount = orderCount,
                UserCount = userCount,
                AllUserCount = adminCount + userCount,
                OrderWeekCount = orderWeekCount,



            };

            var orderDetailPrice = 0;
            var orderDetailList = _orderDetailService.GetAllOrders();
            foreach (var orderDetail in orderDetailList)
            {
                orderDetailPrice = orderDetailPrice + Convert.ToInt32(orderDetail.Price);

            }
            dashboardViewModel.Income = orderDetailPrice;

            dashboardViewModel.PendingOrderCount = _orderService.GetOrders().Where(x => x.OrderStatus == Data.Enums.OrderStatusEnum.Hazırlanıyor).Count();




            return View(dashboardViewModel);
        }
    }
}