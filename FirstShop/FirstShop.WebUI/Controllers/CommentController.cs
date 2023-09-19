using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.WebUI.Extensions;
using FirstShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }
        [HttpPost]
        public IActionResult Add(CommentViewModel commentViewModel)
        {
            var userId = User.GetUserId();
            if(userId == 0)
            {
                return RedirectToAction("Register", "Auth");
            }


            var dto = new AddCommentDto()
            {
                ProductId = commentViewModel.ProductId,
                Comment = commentViewModel.Comment,
                UserId = userId,


            };
            _commentService.AddComment(dto);


            return RedirectToAction("Detail", "Product", new { id = dto.ProductId });
        }
    }
}
