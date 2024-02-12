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

        public T? Get(int id)
        {
            if (data.ContainsKey(id))
            {
                return data[id];
            }
            return default(T);
        }

        public List<T> GetAll()
        {
            return data.Values.ToList();
        }

        public T? Remove(int id)
        {
            data.Remove(id, out T? item);
            return item;
        }
    }
}
