namespace MultiShop.Cargo.DtoLayer.Dtos.CargoOperationsDtos
{
    public class CreateCargoOperationsDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
