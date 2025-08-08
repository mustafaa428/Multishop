using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Feature", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync($"Feature?id={id}");
        }

        public Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("Feature");
            return values;
        }

        public Task<UpdateFeatureDto> GetFeatureByIdAsync(string id)
        {
            var responseMessage = _httpClient.GetAsync($"Feature/{id}");
            var values = responseMessage.Result.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return values;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Feature", updateFeatureDto);
        }
    }
}
