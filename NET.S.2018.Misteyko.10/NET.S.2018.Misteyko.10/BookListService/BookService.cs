using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using BookListStorage;

namespace BookListService
{
    public class BookService : IService
    {
        private IStorable storage;

        public BookService(IStorable storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("");
            }

            this.storage = storage;
        }

        public void AddBook(Book book)
        {
            storage.WriteBook(book);
        }

        public void RemoveBook(Book book)
        {
            List<Book> listOfBooks = storage.ReadAllBooks();
            listOfBooks.Remove(book);
            storage.WriteAllBooks(listOfBooks);
        }

        public Book FindBookByTag()  //add argument
        {
            throw new NotImplementedException();
        }

        public void SortBookByTag()  //add argument
        {
            throw new NotImplementedException();
        }
    }
}
