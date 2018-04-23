using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordChekerForNull : ICheker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException($"{password} is null arg");

            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }

    public class PasswordChekerForLenght: ICheker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if length more than 7 chars 
            if (password.Length < 7)
            {
                return Tuple.Create(false, $"{password} length too short");
            }

            // check if length more than 10 chars for admins
            if (password.Length > 10)
            {
                return Tuple.Create(false, $"{password} length too long");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }

    public class PasswordChekerForContainingLetters : ICheker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }
            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }

    public class PasswordChekerForContainingNumbers : ICheker
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
            {
                return Tuple.Create(false, $"{password} hasn't digits");
            }

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
