using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("SpecialOffer", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"SpecialOffer?id={id}");
        }

        public async Task<List<ResultSpecilaOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSpecilaOfferDto>>("SpecialOffer");
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>($"SpecialOffer/{id}");
            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("SpecialOffer", updateSpecialOfferDto);
        }
    }
}
