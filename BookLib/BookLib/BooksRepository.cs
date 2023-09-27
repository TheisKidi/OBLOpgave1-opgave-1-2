using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository
    {

        private List<Book> books = new List<Book>();

        public BooksRepository()
        {
            books.Add(new Book(1, "Book 1", 100));
            books.Add(new Book(2, "Book 2", 200));
            books.Add(new Book(3, "Book 3", 150));
            books.Add(new Book(4, "Book 4", 120));
            books.Add(new Book(5, "Book 5", 300));
        }

        public List<Book> Get()
        {
            return new List<Book>(books);
        }

        public Book GetById(int id)
        {
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    return b;
                }
            }
            return null;
        }

        public Book Add(Book book)
        {
            int newId = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            book.Id = newId;
            books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book bookToDelete = GetById(id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                return bookToDelete;
            }
            return null;
        }

        public Book Update(int id, Book values)
        {
            Book bookToUpdate = GetById(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = values.Title;
                bookToUpdate.Price = values.Price;
                return bookToUpdate;
            }
            return null;
        }
    }
}

