using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.BussinesLayer.Concrate
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperations> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperations TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperations entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperations entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
