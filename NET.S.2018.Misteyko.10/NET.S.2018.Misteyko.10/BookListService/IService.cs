using BookLib;

namespace BookListService
{
    public interface IService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book FindBookByTag(); //add argument
        void SortBookByTag(); //add argument
    }
}