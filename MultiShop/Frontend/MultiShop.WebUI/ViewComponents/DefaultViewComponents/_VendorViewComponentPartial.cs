using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BrandServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _VendorViewComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorViewComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
    }
}
