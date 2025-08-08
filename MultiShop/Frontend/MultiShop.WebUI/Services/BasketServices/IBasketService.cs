using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);

        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItemAsync(string productId);
    }
}
