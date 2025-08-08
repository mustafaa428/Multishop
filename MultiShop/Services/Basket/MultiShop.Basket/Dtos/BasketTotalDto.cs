using MultiShop.Basket.Dtos;
using System.ComponentModel.DataAnnotations;

public class BasketTotalDto
{
    [Required]
    public string UserId { get; set; }

    [Required]
    public string DiscountCode { get; set; }

    public int DiscountRate { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }

    public decimal TotalPrice => BasketItems.Sum(x => x.Price * x.Quantity);
}
