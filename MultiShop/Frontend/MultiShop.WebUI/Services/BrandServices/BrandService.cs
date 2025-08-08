using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brand", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync($"Brand?id={id}");
        }

        public Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            var values = _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("Brand");
            return values;
        }

        public Task<UpdateBrandDto> GetBrandByIdAsync(string id)
        {
            var responseMessage = _httpClient.GetAsync($"Brand/{id}");
            var values = responseMessage.Result.Content.ReadFromJsonAsync<UpdateBrandDto>();
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brand", updateBrandDto);
        }
    }
}
