namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface GenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);

        T GetById(int id);

        List<T> GetAll();
    }
}
