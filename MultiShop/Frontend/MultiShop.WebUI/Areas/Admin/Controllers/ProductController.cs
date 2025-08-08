using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBag();
            var values = await _productService.GetAllProductAsync();
            return View(values);

        }


        [Route("ProdcutListWithCategory")]
        public async Task<IActionResult> ProdcutListWithCategory()
        {
            ProductViewBag();
            var values = await _productService.GetProductWithCategoriesAsync();
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:7002/api/Product/PrdouctListwithCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            return View(values);
        }

        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBag();
            var values = await _categoryService.GetAllCategoryAsync();
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:7002/api/Categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoyValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId
                                                  }).ToList();
            ViewBag.CategoryValues = categoyValues;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createProductDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("http://localhost:7002/api/Product", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBag();
            var values = await _categoryService.GetAllCategoryAsync();
            //var client1 = _httpClientFactory.CreateClient();
            //var responseMessage1 = await client1.GetAsync("http://localhost:7002/api/Product/" + id);


            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync("http://localhost:7002/api/Categories");
            //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            var productValues = await _productService.GetByIdProductAsync(id);

            //if (responseMessage1.IsSuccessStatusCode)
            //{
            //    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData1);
            //    return View(value);
            //}


            return View(productValues);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProducDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateProducDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("http://localhost:7002/api/Product/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}


            await _productService.UpdateProductAsync(updateProducDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }

        void ProductViewBag()
        {
            ViewBag.V0 = "Ürün işlemleri";
            ViewBag.V1 = "Ana Sayfa";
            ViewBag.V2 = "Ürünler";
            ViewBag.V3 = "Ürün listesi";
        }
    }
}
