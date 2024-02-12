using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryTests;

namespace GenericRepository.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        private Repository<Book> repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new();
            repository.Add(new Book { Title = "Book1", Price = 100 });
            repository.Add(new Book { Title = "Book2", Price = 200 });
            repository.Add(new Book { Title = "Book3", Price = 300 });
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.AreEqual(3, repository.GetAll().Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            Book? book = repository.Get(2);
            Assert.AreEqual("Book2", book?.Title);

            book = repository.Get(4);
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
            Assert.AreEqual(2, repository.GetAll().Count);
            removed = repository.Remove(5);
            Assert.IsNull(removed);
        }
    }
}