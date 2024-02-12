
namespace GenericRepository
{
    public interface IRepository<T> where T : IIdable
    {
        T Add(T item);
        T? Get(int id);
        List<T> GetAll();
        T? Remove(int id);
    }
}