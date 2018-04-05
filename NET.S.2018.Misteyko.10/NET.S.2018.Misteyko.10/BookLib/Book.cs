using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book: IEquatable<Book>, IComparable<Book>, IComparable
    {
        public string ISBN { get; }
        public string AuthorName { get; }
        public string Title { get; }
        public string Publisher { get; }
        public int Year { get; }
        public int NumberOfPages { get; }
        public double Price { get; }

        public Book(string isbn, string authorName, string title, string publisher, int year, int numberOfPages,
            double price)
        {
            ISBN = isbn;
            AuthorName = authorName;
            Title = title;
            Publisher = publisher;
            Year = year;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        #region IEquatable
        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            if (other == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            Book other = obj as Book;

            if (other != null)
            {
                return this.AuthorName.CompareTo(other.AuthorName);
            }
            else
            {
                throw new ArgumentException("Can't compare this objects!");
            }
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("");
            }

            return this.AuthorName.CompareTo(other.AuthorName);
        }

        #endregion

        #region override

        public override bool Equals(object obj)
        {
            Book bookObj = obj as Book;

            if (bookObj == null)
            {
                return false;
            }

            if (ISBN == bookObj.ISBN && AuthorName == bookObj.AuthorName && Title == bookObj.Title &&
                Publisher == bookObj.Publisher && Year == bookObj.Year && NumberOfPages == bookObj.NumberOfPages &&
                Price == bookObj.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() // Soon!!!
        {
            return base.GetHashCode();
        }

        public override string ToString() //Soon!!!
        {
            return base.ToString();
        }

        #endregion

        public string ToString(int output)
        {
            switch (output)
            {
                case 1:
                    return AuthorName + ", " + Title;
                case 2:
                    return AuthorName + ", " + Title + ", " + Publisher + ", " + Year;
                case 3:
                    return ISBN + ", " + AuthorName + ", " + Title + ", " + Publisher + ", " + Year + ", P." +
                           NumberOfPages;
                case 4:
                    return ISBN + ", " + AuthorName + ", " + Title + ", " + Publisher + ", " + Year + ", P." +
                           NumberOfPages + ", " + Price;
                default:
                    throw new ArgumentException("Wrong output type!");
            }
        }
    }
}
