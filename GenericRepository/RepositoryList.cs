namespace GenericRepository
{
    public class RepositoryList<T> : IRepository<T> where T : IIdable
    {
        private readonly List<T> data = new();
        private int nextId = 1;

        public List<T> Get(Predicate<T>? filter = null, IComparer<T>? comparer = null)
        {
            List<T> result = new(data);
            if (filter != null)
            {
                result = result.Where(x => filter(x)).ToList();
            }
            if (comparer != null)
                result.Sort(comparer);
            return result;
        }

        public T? GetById(int id)
        {
            return data.FirstOrDefault(d => d.Id == id);
        }

        public T Add(T item)
        {
            item.Id = nextId++;
            data.Add(item);
            return item;
        }

        public T? Remove(int id)
        {
            T? item = data.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                data.Remove(item);
            }
            return item;
        }

        public T? Update(int id, UpdateDelegate<T> updateDelegate, T values)
        {
            T? item = data.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                T existing = data[id];
                updateDelegate.Invoke(existing, values);
                return existing;
            }
            return item;
        }
    }
}
