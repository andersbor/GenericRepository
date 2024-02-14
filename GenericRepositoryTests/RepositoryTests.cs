using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericRepositoryTests;

namespace GenericRepository.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        private IRepository<Book> repository;

        [TestInitialize]
        public void Initialize()
        {
            //repository = new RepositoryList<Book>();
            repository = new RepositoryDictionary<Book>();
            repository.Add(new Book { Title = "Book3", Price = 100 });
            repository.Add(new Book { Title = "Book2", Price = 200 });
            repository.Add(new Book { Title = "Book1", Price = 300 });
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(3, repository.Get().Count());

            Predicate<Book> filter = b => b.Price > 150;
            Assert.AreEqual(2, repository.Get(filter).Count());

            IComparer<Book> titleComparer = Comparer<Book>.Create((x, y) => x.Title.CompareTo(y.Title));
            List<Book> sorted = repository.Get(comparer: titleComparer);
            Assert.AreEqual("Book1", sorted[0].Title);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Book? book = repository.GetById(2);
            Assert.AreEqual("Book2", book?.Title);

            book = repository.GetById(4);
            Assert.IsNull(book);
        }

        [TestMethod()]
        public void AddTest()
        {
            Book book = new() { Title = "Book4", Price = 400 };
            Book same = repository.Add(book);
            Assert.AreEqual(4, same.Id);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Book? removed = repository.Remove(2);
            Assert.AreEqual("Book2", removed?.Title);
            Assert.AreEqual(2, repository.Get().Count);
            removed = repository.Remove(5);
            Assert.IsNull(removed);
        }

        [TestMethod()]  
        public void UpdateTest()
        {
            Book values = new() { Price = 500 };
            Book? updatedBook = repository.Update(1, (existing, data) => { existing.Price = data.Price; }, values);
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(500, updatedBook.Price);
            Assert.AreEqual(500, repository.GetById(1)?.Price);
            Assert.AreEqual("Book3", updatedBook.Title);

        }   
    }
}