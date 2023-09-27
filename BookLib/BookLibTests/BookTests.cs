using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Xml.Linq;
using System.Diagnostics;

namespace BookLib.Tests
{
    [TestClass()]
    public class BookTests
    {
        private Book book;
        [TestInitialize]
        public void BeforeEachTest()
        {
            book = new Book();
        }

        [TestMethod()]
        [DataRow("Søren")]
        [DataRow("Helle")]
        [DataRow("Hasse")]
        public void BookTitleTestOk(string title)
        {
            // Arrange
            string expectedTitle = title;

            book.Title = title;
            string actualTitle = book.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod()]
        [DataRow("Bo")]
        [DataRow("")]
        [DataRow("E")]
        [ExpectedException(typeof(ArgumentException))]
        public void BookTitleTestFail(string title)
        {
            // Arrange
            string expectedTitle = title;

            book.Title = title;
            string actualTitle = book.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        [DataRow(1199)]
        [DataRow(1)]
        [DataRow(600)]
        public void BookPriceTestOK(int price)
        {
            int expectedPrice = price;

            book.Price = price;
            int actualPrice = book.Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        [DataRow(1201)]
        [DataRow(0)]
        [DataRow(-5)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BookPriceTestFail(int price)
        {
            int expectedPrice = price;

            book.Price = price;
            int actualPrice = book.Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange
            string expectedMessage = $"Id: {book.Id}. Title: {book.Title}. Price: {book.Price}";

            string actualMessage = book.ToString();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ToStringTestFail()
        {
            //Arrange
            string expectedMessage = "Test string";

            string actualMessage = book.ToString();

            Assert.AreNotEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void BookConstructorTest()
        {
            // Arrange
            int expectedId = 1;
            string expectedTitle = "Sample Book";
            int expectedPrice = 100;

            // Act
            Book book = new Book(expectedId, expectedTitle, expectedPrice);

            // Assert
            Assert.AreEqual(expectedId, book.Id);
            Assert.AreEqual(expectedTitle, book.Title);
            Assert.AreEqual(expectedPrice, book.Price);
        }


    }
}