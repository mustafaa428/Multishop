using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal : GenericDal<CargoCustomer>
    {
        CargoCustomer GetCustomerByID(string id);
    }
}
