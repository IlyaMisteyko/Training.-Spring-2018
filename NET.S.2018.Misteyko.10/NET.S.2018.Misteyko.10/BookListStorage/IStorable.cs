using System.Collections.Generic;
using BookLib;

namespace BookListStorage
{
    public interface IStorable
    {
        List<Book> Reader();
        void Writer();
    }
}