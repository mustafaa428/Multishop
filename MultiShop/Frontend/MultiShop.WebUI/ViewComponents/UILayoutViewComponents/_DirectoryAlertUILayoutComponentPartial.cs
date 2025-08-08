using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _DirectoryAlertUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.directory1 = "Ana Sayfa";
            return View();
        }
    }
}
