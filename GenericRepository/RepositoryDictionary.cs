using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class RepositoryDictionary<T> : IRepository<T> where T : IIdable
    {
        private readonly Dictionary<int, T> data = new();
        private int nextId = 1;

        public T Add(T item)
        {
            item.Id = nextId++;
            data.Add(item.Id, item);
            return item;
        }

        public T? GetById(int id)
        {
            if (data.ContainsKey(id))
            {
                return data[id];
            }
            return default;
        }

        public List<T> Get(Predicate<T>? filter = null, IComparer<T>? comparer = null)
        {
            List<T> result = new(data.Values);
            if (filter != null)
            {
                result = result.Where(x => filter(x)).ToList();
            }
            if (comparer != null)
                result.Sort(comparer);
            return result;
        }

        public T? Remove(int id)
        {
            data.Remove(id, out T? item);
            return item;
        }

       

        public T? Update(int id, UpdateDelegate<T> updateDelegate, T values)
        {
            if (data.ContainsKey(id))
            {
                T existing = data[id];
                updateDelegate.Invoke(existing, values);
                return existing;
            }
            return default;
        }
    }
}
