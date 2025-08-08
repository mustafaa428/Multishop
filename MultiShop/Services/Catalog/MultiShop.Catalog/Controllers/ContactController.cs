using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactAsync()
        {
            var values = await _contactService.GetAllContactAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync([FromBody] CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return Ok("İletişim başarıyla gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactAsync([FromBody] UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactAsync(updateContactDto);
            return Ok("İletişim başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContactAsync(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok("İletişim başarıyla silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContactAsync(string id)
        {
            var values = await _contactService.GetByIdContactAsync(id);
            return Ok(values);
        }
    }
}
