using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        private Book book;
        private BooksRepository repo;
        [TestInitialize]
        public void BeforeEachTest()
        {
            book = new Book();
            repo = new BooksRepository();
        }

        [TestMethod()]
        public void GetTestOk()
        {
            List<Book> expectedValue = repo.Get();

            List<Book> actual = repo.Get();

            CollectionAssert.AreEqual(expectedValue, actual);
        }

        [TestMethod()]
        public void GetByIdTestOK()
        {
            Book expectedBook = new Book(1, "Book 1", 100);

            Book actualBook = repo.GetById(expectedBook.Id);

            Assert.AreEqual(expectedBook.Id, actualBook.Id);
            Assert.AreEqual(expectedBook.Title, actualBook.Title);
            Assert.AreEqual(expectedBook.Price, actualBook.Price);
        }

        [TestMethod()]
        public void GetByIdTestReturnsNull()
        {
            int expectedId = 0;

            Book actualBook = repo.GetById(expectedId);

            Assert.IsNull(actualBook);
        }

        [TestMethod()]
        public void AddTestOk()
        {
            int firstCount = repo.Get().Count; 
            Book newBook = new Book(0, "New Book", 200);

            Book addedBook = repo.Add(newBook);

            Assert.IsNotNull(addedBook);
            Assert.IsTrue(addedBook.Id > 0);
            Assert.IsTrue(addedBook.Id == repo.Get().Max(b => b.Id));
            Assert.AreEqual("New Book", addedBook.Title);
            Assert.AreEqual(200, addedBook.Price);

            int finalCount = repo.Get().Count;
            Assert.AreEqual(firstCount + 1, finalCount);
        }
    }
}