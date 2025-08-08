namespace MultiShop.Cargo.DtoLayer.Dtos.CargoOperationsDtos
{
    public class UpdateCargoOperationsDto
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
