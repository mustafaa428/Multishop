using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.FeatureServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _FeatureDefaultViewComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureDefaultViewComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
