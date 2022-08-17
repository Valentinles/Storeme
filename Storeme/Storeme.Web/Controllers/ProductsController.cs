using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Storeme.Entities;
using Storeme.Services.Contracts;
using Storeme.Web.Models.Category;
using Storeme.Web.Models.Product;

namespace Storeme.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }


        public async Task<IActionResult> All(
            string brand, string category, decimal priceFrom, decimal priceTo)
        {
            var products = await this.productService.GetAllProducts(brand, category, priceFrom, priceTo);

            var categories = (await this.categoryService.GetCategories())
                .Select(mapper.Map<CategoryListingViewModel>);

            ViewData["Categories"] = new SelectList(categories, "Title", "Title");

            var result = mapper.Map<IEnumerable<ProductListingViewModel>>(products);

            return this.View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var categories = (await this.categoryService.GetCategories())
                .Select(mapper.Map<CategoryListingViewModel>);

            ViewData["Categories"] = new SelectList(categories, "Id", "Title");

            return this.View();

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ProductBindingModel model)
        {

            var product = mapper.Map<ProductBindingModel, Product>(model);

            if (await this.productService.CreateProduct(product))
            {
                return RedirectToAction("All", "Products");
            }

            return RedirectToAction("Privacy", "Home");

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {

            if (await this.productService.DeleteProduct(id))
            {
                return RedirectToAction("All", "Products");
            }

            return RedirectToAction("Privacy", "Home");

        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {

            var product = await this.productService.GetProduct(id);

            var result = mapper.Map<ProductUpdateModel>(product);

            var categories = (await this.categoryService.GetCategories())
                .Select(mapper.Map<CategoryListingViewModel>);

            ViewData["Categories"] = new SelectList(categories, "Id", "Title");

            return this.View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ProductUpdateModel model)
        {
            var product = mapper.Map<ProductUpdateModel, Product>(model);
            if (await this.productService.UpdateProduct(product))
            {
                return RedirectToAction("All", "Products");
            }
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var product = await this.productService.GetProduct(id);

            var result = mapper.Map<ProductDetailsViewModel>(product);

            return this.View(result);
        }
    }
}
