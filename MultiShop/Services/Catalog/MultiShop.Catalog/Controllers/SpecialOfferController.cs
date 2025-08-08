using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly IspecialOfferService _specialOfferService;

        public SpecialOfferController(IspecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var result = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SpecialOfferGetById(String id)
        {
            var result = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpeacialOfferDto createSpeacialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpeacialOfferDto);
            return Ok("Günün fırsatı başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Günün fırsatları başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Günün fırsatı başarıyla silindi");
        }
    }
}
