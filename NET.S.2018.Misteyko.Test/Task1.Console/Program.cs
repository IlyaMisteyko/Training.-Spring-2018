using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "12345678";
            var ob = new PasswordCheckerService(new SqlRepository(), new PasswordCheker(), s);
            ob.VerifyPassword();

            s = "123456";
            ob = new PasswordCheckerService(new SqlRepository(), new PasswordCheker(), s);
            ob.VerifyPassword();

            s = "1234567891010";
            ob = new PasswordCheckerService(new SqlRepository(), new PasswordCheker(), s);
            ob.VerifyPassword();

            s = "123456ABC";
            ob = new PasswordCheckerService(new SqlRepository(), new PasswordCheker(), s);
            ob.VerifyPassword();

            s = "ABCDEFRre";
            ob = new PasswordCheckerService(new SqlRepository(), new PasswordCheker(), s);
            ob.VerifyPassword();

            System.Console.ReadKey();
        }
    }
}
