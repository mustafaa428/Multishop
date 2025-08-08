using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _OfferDiscountViewComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountViewComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
