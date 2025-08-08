using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);
        }
        public Task DeleteBasketAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();

            if (values == null)
            {
                values = new BasketTotalDto();
            }

            // BasketItems null olabilir, kontrol edip oluşturuyoruz
            if (values.BasketItems == null)
            {
                values.BasketItems = new List<BasketItemDto>();
            }

            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }

            await SaveBasket(values);
        }


        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }
    }
}
