using GenericRepository;

namespace GenericRepositoryTests
{
    public class Book : IIdable
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
    }
}
