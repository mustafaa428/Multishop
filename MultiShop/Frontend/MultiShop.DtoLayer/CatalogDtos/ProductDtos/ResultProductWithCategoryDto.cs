using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProducPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDesctription { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
