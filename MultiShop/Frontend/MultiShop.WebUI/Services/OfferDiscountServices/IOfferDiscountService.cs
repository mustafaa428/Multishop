using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto;

namespace MultiShop.WebUI.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id);
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);

    }
}
