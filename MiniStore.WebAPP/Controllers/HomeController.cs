using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniStore.WebAPP.Models;
using MiniStore.WebAPP.Services;

namespace MiniStore.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly APIService _apiService;

        public HomeController(ILogger<HomeController> logger, APIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index(int? categoryId)
        {
            List<CategoryModel> categories;
            List<ProductModel> products;

            if (categoryId != null)
            {
                categories = _apiService.GetCategories(categoryId, null);
                products = _apiService.GetProducts(categoryId);
            }
            else
            {
                categories = _apiService.GetCategories(null, null);
                products = _apiService.GetDefaultProducts();
            }

            var mainPageModel = new MainPageModel()
            {
                Categories = categories,
                Products = products
            };
            return View(mainPageModel);
        }

        public IActionResult SearchProductOrCategory()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchProductOrCategory(string searchData)
        {
            var searchResultModel = new SearchResultModel();
            var searchResults = _apiService.Search(searchData.ToLowerInvariant());

            searchResultModel = searchResults;
            return View(searchResultModel);
        }

        [HttpPost]
        public JsonResult GetMainCategoryOfSubCategory(int subCategoryId, int parentCategoryId)
        {
            var mainCategoryNameOfSubCategory = _apiService.GetCategories(subCategoryId, parentCategoryId);

            return Json(mainCategoryNameOfSubCategory);
        }
    }
}
