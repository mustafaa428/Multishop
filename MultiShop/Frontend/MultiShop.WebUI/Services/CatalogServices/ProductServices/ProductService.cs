using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("Product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"Product?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            //var responseMessage = await _httpClient.GetAsync("Product");
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("Product");
            return values;

            //var responseMessage = await  _httpClient.GetAsync("Product");
            //var jsonData = responseMessage.Content.ReadAsStringAsync();
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            //return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Product/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Product/PrdouctListwithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = _httpClient.GetAsync($"Product/PrdouctListwithCategoryByCategoryId?categoryId={categoryId}");
            var jsonData = await responseMessage.Result.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("Product", updateProductDto);
        }
    }
}
