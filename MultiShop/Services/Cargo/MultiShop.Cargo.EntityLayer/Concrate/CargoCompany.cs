using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.EntityLayer.Concrate
{
    public class CargoCompany
    {
        [Key]
        public int CargoCompanyId { get; set; }
        public string CargoCompanyName { get; set; }
    }
}
