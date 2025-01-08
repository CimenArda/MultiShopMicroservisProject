using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutFooterComponentPartial  : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
