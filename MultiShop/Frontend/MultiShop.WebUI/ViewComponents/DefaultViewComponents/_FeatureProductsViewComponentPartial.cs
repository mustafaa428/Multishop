using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _FeatureProductsViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllProductAsync();
            return View(products);
        }
    }
}
