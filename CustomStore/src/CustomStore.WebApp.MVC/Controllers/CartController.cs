using CustomStore.Catalog.Application.Interfaces;
using CustomStore.Core.Communication;
using CustomStore.Sales.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomStore.WebApp.MVC.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly IProductAppService productAppService;
        private readonly ICustomMediatrHandler mediatrHandler;

        public CartController(
            IProductAppService productAppService,
            ICustomMediatrHandler mediatrHandler)
        {
            this.productAppService = productAppService;
            this.mediatrHandler = mediatrHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("my-cart")]
        public async Task<IActionResult> AddItem(Guid id, int quantity)
        {
            var product = await productAppService.GetById(id);

            if (product == null)
            {
                return BadRequest();
            }

            if (product.Quantity < quantity)
            {
                TempData["Error"] = "Product quantity unavailable in stock";
                return RedirectToAction("ProductDetail", "Catalog", new { id });
            }

            var command = new AddOrderItemCommand(ClientId, product.Id, product.Name, quantity, product.Price);
            await mediatrHandler.SendCommand(command);

            TempData["Error"] = "Product unavailable";
            return RedirectToAction("ProductDetail", "Catalog", new { id });
        }
    }
}
