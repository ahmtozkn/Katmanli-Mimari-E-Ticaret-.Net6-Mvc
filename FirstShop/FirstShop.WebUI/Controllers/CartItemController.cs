using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class CartItemController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartService cartService, IProductService productService, ICartItemService cartItemService)
        {
            _productService = productService;
            _cartService = cartService;
            _cartItemService = cartItemService;
        }


        public IActionResult Add(int productId)
        {
            var userid = User.GetUserId();
            var userId = Convert.ToInt32(userid);
            if (userId == 0)
            {
                return RedirectToAction("Register", "Auth");
            }
            //var hasCart = _cartService.GetCart(userid);
            //if(hasCart == null) {  

            var cartDto = new AddCartDto()
            {
                UserId = userid
            };

            _cartService.AddCart(cartDto);
            //}

            var productsdto = _productService.GetProductById(productId);
            var getCartDto = _cartService.GetCart(userId);
            var cartItemList = _cartItemService.GetAllCartItems();
            var hasProduct = cartItemList.FirstOrDefault(x => x.ProductId == productId && x.CartId == getCartDto.Id);
            if (hasProduct is null)
            {
                var cartItemDto = new AddCartItemDto();

                cartItemDto.CartId = getCartDto.Id;
                cartItemDto.ProductId = productId;
                cartItemDto.Quantity = +1;
                cartItemDto.Price = cartItemDto.Quantity * productsdto.UnitPrice;


                _cartItemService.AddCartItem(cartItemDto);


                return Redirect("List");
            }


            var editItemDto = new EditCartItemDto();
            editItemDto.Quantity = hasProduct.Quantity;
            editItemDto.Price = 0;

            editItemDto.Id = hasProduct.Id;
            editItemDto.CartId = hasProduct.CartId;
            editItemDto.ProductId = hasProduct.ProductId;
            editItemDto.Quantity += 1;
            editItemDto.Price = editItemDto.Quantity * productsdto.UnitPrice;





            _cartItemService.EditCartItem(editItemDto);
            return Redirect("List");







        }

        public IActionResult Reduce(int productId)
        {

            var userId = User.GetUserId();
            var allCart = _cartItemService.GetAllCartItems();
            var getCartDto = _cartService.GetCart(userId);
            var reduceCart = allCart.Where(x => x.ProductId == productId && x.CartId == getCartDto.Id).FirstOrDefault();
            if (reduceCart.Quantity == 1)
            {
                _cartItemService.DeleteCartItem(reduceCart.Id);
                return Redirect("List");
            }


            var product = _productService.GetProductById(productId);
            var productUnitPrice = product.UnitPrice;
            var editCartItemDto = new EditCartItemDto()
            {
                Id = reduceCart.Id,
                ProductId = productId,
                CartId = getCartDto.Id,
                Quantity = reduceCart.Quantity - 1,
                Price = reduceCart.Price - productUnitPrice
            };
            _cartItemService.EditCartItem(editCartItemDto);



            return Redirect("List");
        }


        public IActionResult Increase(int productId)
        {
            var userId = User.GetUserId();
            var userid = Convert.ToInt32(userId);
            var allCart = _cartItemService.GetAllCartItems();
            var getCartDto = _cartService.GetCart(userid);
            var increaseCart = allCart.Where(x => x.ProductId == productId && x.CartId == getCartDto.Id).FirstOrDefault();
            var product = _productService.GetProductById(productId);
            var productUnitPrice = product.UnitPrice;
            var editCartItemDto = new EditCartItemDto();

            editCartItemDto.Id = increaseCart.Id;
            editCartItemDto.ProductId = productId;
            editCartItemDto.CartId = getCartDto.Id;
            editCartItemDto.Quantity = increaseCart.Quantity + 1;
            editCartItemDto.Price = productUnitPrice * editCartItemDto.Quantity;



            _cartItemService.EditCartItem(editCartItemDto);


            return Redirect("List");
        }


        public IActionResult Delete(int id)
        {

            _cartItemService.DeleteCartItem(id);

            return RedirectToAction("List");



        }


        public IActionResult List()

        {  var userid = User.GetUserId(); 
            var userId = Convert.ToInt32(userid);

            var hasCart = _cartService.GetCart(userId);
            if(hasCart is null)
            {
                var cartDto = new AddCartDto()
              {
                UserId = userId
              };
           _cartService.AddCart(cartDto);

          }
           
            decimal? totalprice = 0;
            var getCartDto = _cartService.GetCart(userId);
            var cartItemDto = _cartItemService.GetAllCartItems();
            foreach (var item in cartItemDto)
            {
                if (item.CartId == getCartDto.Id)
                {
                    totalprice = totalprice + item.Price;

                }


            }
            ViewBag.Total = totalprice;


            var cartItemView = cartItemDto.Where(x => x.CartId == getCartDto.Id).Select(x => new CartItemViewModel()
            {
                Id = x.Id,
                CartId = x.CartId,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.ProductName,
                ImagePath = x.ImagePath



            }).ToList();

           
                return View(cartItemView);

        }
    }
}
