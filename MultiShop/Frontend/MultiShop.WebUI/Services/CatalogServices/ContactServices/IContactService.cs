using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContacDto>> GetAllContactsAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
    }
}
