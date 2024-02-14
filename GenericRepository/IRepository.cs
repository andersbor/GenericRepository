

namespace GenericRepository
{
    public delegate void UpdateDelegate<T>(T existing, T data);

    public interface IRepository<T> where T : IIdable
    {
       
        T Add(T item);
        T? GetById(int id);
        List<T> Get(Predicate<T>? filter=null, IComparer<T>? comparer=null);
        T? Remove(int id);
        T? Update(int id, UpdateDelegate<T> updateDelegate, T values);
    }
}