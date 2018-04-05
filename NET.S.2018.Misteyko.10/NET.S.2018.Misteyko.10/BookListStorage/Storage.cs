using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace BookListStorage
{
    public class Storage : IStorable
    {
        private readonly string path;

        public Storage(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException($"{path} can't be null!");
            }

            this.path = path;
        }

        public List<Book> ReadAllBooks()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                List<Book> listOBooks = new List<Book>();

                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string authorName = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int year = reader.ReadInt32();
                    int numberOfPages = reader.ReadInt32();
                    double price = reader.ReadDouble();

                    listOBooks.Add(new Book(isbn, authorName, title, publisher, year, numberOfPages, price));
                }

                return listOBooks;
            }
        }

        public void WriteAllBooks(List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Book book in books)
                {
                    WriteBook(book);
                }

            }
        }

        public void WriteBook(Book book)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(book.ISBN);
                writer.Write(book.AuthorName);
                writer.Write(book.Title);
                writer.Write(book.Publisher);
                writer.Write(book.Year);
                writer.Write(book.NumberOfPages);
                writer.Write(book.Price);
            }
        }
    }
}
