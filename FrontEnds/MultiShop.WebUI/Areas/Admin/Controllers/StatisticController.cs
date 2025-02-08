using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.getBrandCount= getBrandCount;

            var getProductCount = await _catalogStatisticService.GetProductCount();
            ViewBag.getProductCount= getProductCount;

            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.getCategoryCount= getCategoryCount;

            var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.getProductAvgPrice= getProductAvgPrice;

            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.getMaxPriceProductName= getMaxPriceProductName;

            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.getMinPriceProductName = getMinPriceProductName;

            var getUserCount = await _userStatisticService.GetUsercount();
            ViewBag.getUserCount= getUserCount;


            var getActiveCommentCount = await _commentStatisticService.GetActiveCommentCount();
            ViewBag.getActiveCommentCount= getActiveCommentCount;

            var getPassiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
            ViewBag.getPassiveCommentCount= getPassiveCommentCount;

            var getTotalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            ViewBag.getTotalCommentCount= getTotalCommentCount;

            var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.getDiscountCouponCount = getDiscountCouponCount;

            var getMessageTotalCount = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.getMessageTotalCount = getMessageTotalCount;


            return View();
        }


    }
}
