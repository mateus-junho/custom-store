using CustomStore.Catalog.Application.DTOs;
using CustomStore.Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomStore.WebApp.MVC.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly IProductAppService productAppService;

        public AdminProductsController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        [Route("admin-products")]
        public async Task<IActionResult> Index()
        {
            return View("../AdminProducts/Index", await productAppService.GetAll());
        }

        [Route("new-product")]
        public async Task<IActionResult> NewProduct()
        {
            return View("../AdminProducts/NewProduct", await FillCategories(new ProductDto()));
        }

        [Route("new-product")]
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid) return View(await FillCategories(productDto));

            await productAppService.AddProduct(productDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            return View("../AdminProducts/UpdateProduct", await FillCategories(await productAppService.GetById(id)));
        }

        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto productDto)
        {
            ModelState.Remove("Quantity");
            if (!ModelState.IsValid) return View("../AdminProducts/UpdateProduct", await FillCategories(productDto));

            await productAppService.UpdateProduct(productDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("products-update-stock")]
        public async Task<IActionResult> UpdateStock(Guid id)
        {
            return View("../AdminProducts/Stock", await productAppService.GetById(id));
        }

        [HttpPost]
        [Route("products-update-stock")]
        public async Task<IActionResult> UpdateStock(Guid id, int quantity)
        {
            if (quantity > 0)
            {
                await productAppService.AddStock(id, quantity);
            }
            else
            {
                await productAppService.DebitStock(id, quantity);
            }

            return View("../AdminProducts/Index", await productAppService.GetAll());
        }

        private async Task<ProductDto> FillCategories(ProductDto product)
        {
            product.CategoriesOptions = await productAppService.GetCategories();
            return product;
        }
    }
}
