using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.EntityLayer.Concrate
{
    public class CargoOperations
    {
        [Key]
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
