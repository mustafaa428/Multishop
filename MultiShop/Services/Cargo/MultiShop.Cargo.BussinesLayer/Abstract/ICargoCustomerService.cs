using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.BussinesLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCustomerByID(string id);
    }
}
