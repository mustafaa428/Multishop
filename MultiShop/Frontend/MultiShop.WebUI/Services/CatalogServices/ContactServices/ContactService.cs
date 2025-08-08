using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("Contact", createContactDto);
        }

        public Task<List<ResultContacDto>> GetAllContactsAsync()
        {
            var response = _httpClient.GetFromJsonAsync<List<ResultContacDto>>("Contact");
            return response;
        }
    }
}
