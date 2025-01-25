using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturedComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

		public _DefaultFeaturedComponentPartial(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
          var values =await _featureService.GetAllFeatureAsync();
            return View(values);
        }

    }
}
