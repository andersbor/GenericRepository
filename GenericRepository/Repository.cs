namespace GenericRepository
{
    public class Repository<T> where T: IIdable
    {
        private readonly List<T> data = new();
        private int nextId = 1;

        public List<T> GetAll()
        {
            return new(data);
        }

        public T? Get(int id)
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

    }
}
