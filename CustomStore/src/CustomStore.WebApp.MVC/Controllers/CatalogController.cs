using CustomStore.Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomStore.WebApp.MVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductAppService productAppService;

        public CatalogController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("catalog")]
        public async Task<IActionResult> Index()
        {
            return View("../Catalog/Index", await productAppService.GetAll());
        }

        [HttpGet]
        [Route("product-detail/{id}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            return View("../Catalog/ProductDetail", await productAppService.GetById(id));
        }
    }
}
