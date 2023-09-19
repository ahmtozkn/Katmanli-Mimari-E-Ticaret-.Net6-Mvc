using FirstShop.Business.Services;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;
        public OrderDetailController(IOrderDetailService orderDetailService, IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _productService = productService;

        }
        public IActionResult List(int id)
        {
            var list = _orderDetailService.GetAllOrders();
            var orderViewModel = list.Where(X => X.OrderId == id).Select(x => new OrderDetailViewModel()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ImagePath = x.ImagePath,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,




            }).ToList();




            return View(orderViewModel);
        }
    }
}
