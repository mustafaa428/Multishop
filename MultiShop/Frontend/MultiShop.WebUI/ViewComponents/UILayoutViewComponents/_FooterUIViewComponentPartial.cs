using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.AboutServices;
namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUIViewComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _FooterUIViewComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
