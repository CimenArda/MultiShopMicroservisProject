using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultSpecialOfferComponentPartial : ViewComponent
    {
       private readonly ISpecialOfferService _specialOfferService;

		public _DefaultSpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

    }
}
