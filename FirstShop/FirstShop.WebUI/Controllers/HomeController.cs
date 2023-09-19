using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("urunler/{categoryName}/{categoryId}")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.categoryID = categoryId;

            return View();
        }
    }
}
