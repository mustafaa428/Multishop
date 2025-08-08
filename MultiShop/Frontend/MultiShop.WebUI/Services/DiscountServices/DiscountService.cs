using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessaege = await _httpClient.GetAsync($"Discounts/GetCodeDetailByCodeAsync?code={code}");
            var values = await responseMessaege.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responceMessage = await _httpClient.GetAsync($"Discounts/GetDiscountCouponRate?code={code}");
            var values = await responceMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
