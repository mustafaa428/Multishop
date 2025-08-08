
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.SliderServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _CarouselViewComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselViewComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
