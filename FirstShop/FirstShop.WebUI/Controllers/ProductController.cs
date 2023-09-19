using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;


        public ProductController(IProductService productService, ICategoryService categoryService, IUserService userService, ICommentService commentService, ILikeService likeService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
            _commentService = commentService;
            _likeService = likeService;
        }

        public IActionResult Detail(int id)
        {
            var productDto = _productService.GetDetailProductById(id);
            var categoryDto = _categoryService.GetCategoryById(productDto.CategoryId);
            var userDto = _userService.GetById(productDto.UserId);

            var productsViewModel = new ProductViewModel()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                CategoryName = categoryDto.Name,
                CategoryId = productDto.CategoryId,
                UnitInStock = productDto.UnitInStock,
                UnitPrice = productDto.UnitPrice,
                ImagePath = productDto.ImagePath,
                UserName = userDto.FirstName + " " + userDto.LastName
            };

            var entity = _commentService.GetAllComments();

            var user1 = User.GetUserId();
            var user2 = Convert.ToInt32(user1);
            ViewBag.Id = user2;

            var likeList = _likeService.GetAllLike();
            var likeGetDto = likeList.FirstOrDefault(x => x.UserId == user2 && x.ProductId == id);
            if (likeGetDto is not null)
            {
                var likeViewModel = new LikeViewModel()
                {
                    Id = likeGetDto.Id,
                    IsLiked = likeGetDto.IsLiked,

                };

                ViewBag.Like = likeViewModel;
            }







            var Comments = entity.OrderByDescending(x => x.CreatDate).Where(x => x.ProdcutId == productDto.Id).Select(x => new CommentViewModel()
            {
                Id = x.Id,
                Comment = x.Comment,
                CreatedDate = x.CreatDate,
                UserName = x.UserName,



            }).ToList();

            ViewBag.Product = productsViewModel;

            var productDetailViewModel = new ProductDetailList()
            {
                commentList = Comments,

                productList = productsViewModel

            };

            ViewBag.ProductDetail = productDetailViewModel;


            return View();
        }

    }
}
