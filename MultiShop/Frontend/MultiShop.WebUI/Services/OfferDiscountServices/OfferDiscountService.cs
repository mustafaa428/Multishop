using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto;

namespace MultiShop.WebUI.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscount", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync($"OfferDiscount?id={id}");
        }

        public Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("OfferDiscount");
            return values;
        }

        public Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id)
        {
            var responseMessage = _httpClient.GetAsync($"OfferDiscount/{id}");
            var values = responseMessage.Result.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
            return values;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscount", updateOfferDiscountDto);
        }
    }
}
