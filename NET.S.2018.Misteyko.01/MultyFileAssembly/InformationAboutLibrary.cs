using System;
using Library;

class Program
{
	static void Main()
	{
		Reader ob1 = new Reader();
		ob1.ReaderInfo();
		
		Librarian ob = new Librarian();
		ob.LibrarianInfo();
		
		Console.ReadLine();
	}
}