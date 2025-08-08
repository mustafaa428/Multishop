using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _ProductImageServices;

        public ProductImageController(IProductImageService ProductImageServices)
        {
            _ProductImageServices = ProductImageServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageServices.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {

            var values = await _ProductImageServices.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageServices.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageServices.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageServices.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün remi başarıyla güncellendi.");
        }

        [HttpGet("ProductImageByProductId")]
        public async Task<IActionResult> ProductImageByProductId(string id)
        {
            var values = await _ProductImageServices.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }
    }
}