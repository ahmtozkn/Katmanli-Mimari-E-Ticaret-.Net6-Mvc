using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;
        private readonly IProductService _productService;
        public LikeController(ILikeService likeService, IProductService productService)
        {
            _likeService = likeService;
            _productService = productService;
        }
        public IActionResult Add(int productId)
        {
            var userId = User.GetUserId();
            var hasLike = _likeService.GetAllLike().FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);
            if (userId == 0)
            {
                return RedirectToAction("Register", "Auth");
            }

            if (hasLike is null)
            {
                var addLikeDto = new AddLikeDto()
                {
                    ProductId = productId,
                    UserId = userId,
                    IsLiked = true,


                };
                _likeService.AddLike(addLikeDto);

            }
            else
            {



                var editLikeDto = new EditLikeDto()
                {
                    Id = hasLike.Id,
                    ProductId = productId,
                    UserId = userId,
                    IsLiked = true,


                };

                _likeService.EditLike(editLikeDto);


            }

            return RedirectToAction("Detail", "Product", new { id = productId });
        }

        public IActionResult Remove(int productId)
        {
            var userId = User.GetUserId();
            var hasLike = _likeService.GetAllLike().FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);
            var editLikeDto = new EditLikeDto()
            {
                Id = hasLike.Id,
                ProductId = productId,
                UserId = userId,
                IsLiked = false,


            };
            _likeService.EditLike(editLikeDto);


            return RedirectToAction("Detail", "Product", new { id = productId });



        }

        public IActionResult List()
        {
            var userId = User.GetUserId();
            var listLikeProduct = new List<ListProductDto>();

            var listLike = _likeService.GetAllLike().Where(x => x.IsLiked == true && x.UserId == userId);
            var productListDto = _productService.GetProducts();
            foreach (var product in productListDto)
            {
                foreach (var item in listLike)

                {
                    if (product.Id == item.ProductId)
                    {

                        listLikeProduct.Add(product);

                    }


                }

            }

            var productViewModel = listLikeProduct.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Name = x.Name,
                CategoryName = x.CategoryName,
                ImagePath = x.ImagePath,
            }).ToList();



            return View(productViewModel);
        }

        public IActionResult ListRemove(int productId)
        {
            var userId = User.GetUserId();
            var hasLike = _likeService.GetAllLike().FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);
            var editLikeDto = new EditLikeDto()
            {
                Id = hasLike.Id,
                ProductId = productId,
                UserId = userId,
                IsLiked = false,


            };
            _likeService.EditLike(editLikeDto);


            return RedirectToAction("List");



        }
    }
}
