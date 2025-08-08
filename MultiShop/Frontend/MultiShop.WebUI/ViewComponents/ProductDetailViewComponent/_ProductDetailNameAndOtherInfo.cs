using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailNameAndOtherInfo : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailNameAndOtherInfo(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage1 = await client.GetAsync("http://localhost:7002/api/Product?id=" + id);
            //if (responseMessage1.IsSuccessStatusCode)
            //{
            //    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData1);
            //    return View(value);
            //}
            //return View();
        }
    }
}
