using System.Collections.Generic;
using BookLib;

namespace BookListStorage
{
    public interface IStorable
    {
        List<Book> ReadAllBooks();
        void WriteAllBooks(List<Book> books);
        void WriteBook(Book book);
    }
}