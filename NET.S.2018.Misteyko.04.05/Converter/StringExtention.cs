using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// Class which converts string to decimal number.
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// Converts different number systems to decimal.
        /// </summary>
        /// <param name="source">Main string.</param>
        /// <param name="notation">Object of class "Notation" which describe number system.</param>
        /// <returns>Result of converting.</returns>
        public static int ToDecimalConverter(this string source, Notation notation)
        {
            string sourceToUpper = source.ToUpper();
            int result = 0;

            for (int i = sourceToUpper.Length - 1, j = 1; i >= 0; i--, j *= notation.Basis)
            {
                result += notation.DesiredHalfOfTheAlphabet.IndexOf(sourceToUpper[i]) * j;
            }

            return result;
        }
    }

    /// <summary>
    /// Class which describe number system.
    /// </summary>
    public class Notation
    {
        /// <summary>
        /// Field of the alphabet
        /// </summary>
        private string alphabet = "0123456789ABCDEF";

        /// <summary>
        /// Initializes a new instance of the <see cref="Notation"/> class.
        /// </summary>
        /// <param name="basis">The basis.</param>
        /// <exception cref="System.ArgumentException">Wrong basis!</exception>
        public Notation(int basis)
        {
            if (basis < 2 || basis > 16)
            {
                throw new ArgumentException("Wrong basis!");
            }

            this.Basis = basis;
            this.DesiredHalfOfTheAlphabet = this.alphabet.Substring(0, this.Basis);
        }

        public string Alphabet
        {
            get { return alphabet; }
        }

        /// <summary>
        /// Gets basis.
        /// </summary>
        /// <value>
        /// Gets basis.
        /// </value>
        public int Basis { get; }

        /// <summary>
        /// Gets desired half of the alphabe.
        /// </summary>
        /// <value>
        /// Gets desired half of the alphabet.
        /// </value>
        public string DesiredHalfOfTheAlphabet { get; }
    }
}
