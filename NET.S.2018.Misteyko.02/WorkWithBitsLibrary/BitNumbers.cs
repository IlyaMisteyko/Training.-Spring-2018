using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithBitsLibrary
{
    /// <summary>
    /// Work with bit numbers
    /// </summary>
    public class BitNumbers
    {
        /// <summary>
        /// Converts the number in bits.
        /// </summary>
        /// <param name="num">Converting number.</param>
        /// <returns>Result of converting.</returns>
        public static byte[] ConvertNumberInBits(int num)
        {
            const int numberOfBitsInInt = 32;
            byte[] numberAsBits = new byte[numberOfBitsInInt];

            for (int i = numberAsBits.Length - 1; i >= 0 && num != 0; i--, num /= 2)
            {
                numberAsBits[i] = (byte)(num % 2);
            }

            return numberAsBits;
        }

        /// <summary>
        /// Inserts the number.
        /// </summary>
        /// <param name="numberSource">Source number.</param>
        /// <param name="numberIn">In number.</param>
        /// <param name="i">Index i.</param>
        /// <param name="j">Index j.</param>
        /// <returns>Resulting number.</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            byte[] numberSourceAsBits = ConvertNumberInBits(numberSource);
            byte[] numberInAsBits = ConvertNumberInBits(numberIn);

            const int numberOfBitsInInt = 32;
            int length = j - i + 1;
            int index = numberOfBitsInInt - length;
            int newJ = numberOfBitsInInt - j - 1;
            Array.Copy(numberInAsBits, index, numberSourceAsBits, newJ, length);

            return ConvertFromBitsToInteger(numberSourceAsBits);
        }

        /// <summary>
        /// Converts from bits to integer.
        /// </summary>
        /// <param name="numberAsBits">The number as bits.</param>
        /// <returns>Converted number.</returns>
        public static int ConvertFromBitsToInteger(byte[] numberAsBits)
        {
            int result = 0;
            for(int i = numberAsBits.Length - 1, j = 0; i >= 0; i--, j++)
            {
                result += numberAsBits[i] * (int)Math.Pow(2, j);
            }

            return result;
        }
    }
}
