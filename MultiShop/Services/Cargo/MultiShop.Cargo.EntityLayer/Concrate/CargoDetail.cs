using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.EntityLayer.Concrate
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int BarCode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }

    }
}
