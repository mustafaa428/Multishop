using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brand)
        {
            _brandService = brand;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var result = await _brandService.GetAllBrandAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BetByIdBrand(string id)
        {
            var result = await _brandService.GetByIdBrandAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return Ok("marka başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Marka başarıyla silindi");
        }
    }
}
