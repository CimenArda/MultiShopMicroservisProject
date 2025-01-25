using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

		public _DefaultBrandComponentPartial(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
           var values =await  _brandService.GetAllBrandAsync();
            return View(values);
        }


    }
}
