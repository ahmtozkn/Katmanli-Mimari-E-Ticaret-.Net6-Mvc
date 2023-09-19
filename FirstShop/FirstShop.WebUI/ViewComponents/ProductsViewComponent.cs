using FirstShop.Business.Services;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.ViewComponents
{
    public class ProductsViewComponent:ViewComponent
    {
        private readonly IProductService _productService;
        public ProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int? categoryId, int? productId)
        {

            var productDtos = _productService.GetProductByIdCategoryId(categoryId);


            var viewModel = productDtos.Select(x => new ProductViewModel
            {


                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                UnitInStock = x.UnitInStock,
                UnitPrice = x.UnitPrice,
                ImagePath = x.ImagePath



            }).ToList();

            var deleteView = viewModel.FirstOrDefault(x => x.Id == productId);
            viewModel.Remove(deleteView);



            return View(viewModel);
        }
    }
}
