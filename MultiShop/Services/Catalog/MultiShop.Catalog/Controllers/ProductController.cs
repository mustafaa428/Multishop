using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;

        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productServices.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {

            var values = await _productServices.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productServices.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpGet("PrdouctListwithCategory")]
        public async Task<IActionResult> PrdouctListwithCategory()
        {
            var values = await _productServices.GetProductWithCategoriesAsync();
            return Ok(values);
        }

        [HttpGet("PrdouctListwithCategoryByCategoryId")]
        public async Task<IActionResult> PrdouctListwithCategoryByCategoryId(string categoryId)
        {
            var values = await _productServices.GetProductWithCategoryByCategoryIdAsync(categoryId);
            return Ok(values);
        }
    }
}
