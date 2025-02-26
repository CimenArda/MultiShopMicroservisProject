﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoriesComponentPartial : ViewComponent
    {
		private readonly ICategoryService _categoryService;
		public _DefaultCategoriesComponentPartial(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _categoryService.GetAllCategoryAsync();
			return View(values);
		}

	}
}
