using System.Collections.Generic;
using Task1.Solution;

namespace Task1
{
    public class SqlRepository: IRepository
    {
        public List<string> passwords = new List<string>();

        public void Create(string password)
        {
            passwords.Add(password);
        }
    }
}