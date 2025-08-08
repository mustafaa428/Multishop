using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShopingCardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShopingCardController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalnewPriceWithDiscount)
        {
            ViewBag.totalnewPriceWithDiscount = totalnewPriceWithDiscount;
            ViewBag.Code = code;
            ViewBag.DiscountRate = discountRate;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Sepet";
            ViewBag.directory3 = "Sepetteki ürünler";
            var values = await _basketService.GetBasketAsync();
            ViewBag.Total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + (values.TotalPrice / 100 * 10);
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.Tax = (values.TotalPrice / 100 * 10);
            return View();
        }

        [HttpGet("/ShopingCard/AddBasketItem/{id}")]
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductImageUrl = values.ProductImageUrl,
                Price = values.ProducPrice,
                Quantity = 1 // Default quantity is set to 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            var result = await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index", "ShopingCard");
        }
    }
}