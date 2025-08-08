using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProducPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDesctription { get; set; }
        //public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
