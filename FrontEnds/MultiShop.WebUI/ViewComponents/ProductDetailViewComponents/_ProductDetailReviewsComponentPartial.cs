using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewsComponentPartial : ViewComponent
    {
      private readonly ICommentService _commentService;

        public _ProductDetailReviewsComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

          var values = await _commentService.GetAllCommentByProductIDAsync(id);
            return View(values);
        }
    }
}
