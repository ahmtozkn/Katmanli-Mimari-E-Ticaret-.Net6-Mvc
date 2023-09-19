using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IProductService _productService;
        public OrderController(IOrderDetailService orderDetailService, IOrderService orderService, ICartItemService cartItemService, ICartService cartService, IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _cartItemService = cartItemService;
            _cartService = cartService;
            _productService = productService;
        }
        public IActionResult Add(int addressId,int paymentMethodId)
        {


            var user = User.GetUserId();
            var userid = Convert.ToInt32(user);
            var orderDto = new AddOrderDto()
            {
                UserId = userid,
                AddressId = addressId,
                PaymentMethodId= paymentMethodId
            };
            var OrderId = _orderService.AddOrder(orderDto);

            var orders = _orderService.GetOrders();
            var order = orders.Where(x => x.CreatedDate == DateTime.Now).FirstOrDefault();
            var getcartdto = _cartService.GetCart(userid);
            var cartItem = _cartItemService.GetAllCartItems();
            var cartItemDto = cartItem.Where(x => x.CartId == getcartdto.Id).ToList();
            var total = 0;



            var orderDetailDto = new AddOrderDetailDto();
            foreach (var item in cartItemDto)
            {
                orderDetailDto.ProductId = item.ProductId;
                orderDetailDto.Quantity = item.Quantity;
                orderDetailDto.Price = item.Price;
                orderDetailDto.OrderId = OrderId;
                orderDetailDto.ImagePath = item.ImagePath;

                var productDto = _productService.GetProductById(item.ProductId);
                if (productDto.UnitInStock > item.Quantity || productDto.UnitInStock == item.Quantity)
                {
                    productDto.UnitInStock = productDto.UnitInStock - item.Quantity;
                    _productService.EditProduct(productDto);
                    _orderDetailService.AddOrderDetail(orderDetailDto);
                }


            }

            var delete = cartItem.Where(X => X.CartId == getcartdto.Id).ToList();
            foreach (var item in delete)
            {
                _cartItemService.DeleteCartItem(item.Id);
            }


            return RedirectToAction("List", "OrderDetail", new { id = OrderId });

        }

        public IActionResult List()
        {
            var userId = User.GetUserId();
            var userid = Convert.ToInt32(userId);
            var orders = _orderService.GetOrders();
            var orderdetails = _orderDetailService.GetAllOrders();


            var orderViewModel = orders.OrderByDescending(x => x.CreatedDate).Where(x => x.UserId == userid).Select(x => new OrderViewModel()
            {
                Id = x.Id,
                UserId = userid,
                CreatedDate = x.CreatedDate,
                OrderStatus = x.OrderStatus,
                ImagePaths = orderdetails.Where(a => a.OrderId == x.Id).ToList(),
                Adres = x.Address,
                PaymentMethodName=x.PaymentMethodName,


            }).ToList();
            return View(orderViewModel);



        }
    }
}
