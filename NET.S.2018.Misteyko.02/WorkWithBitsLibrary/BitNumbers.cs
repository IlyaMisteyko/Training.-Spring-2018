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
        /// Inserts one number into another.
        /// </summary>
        /// <param name="numberSource">Source number.</param>
        /// <param name="numberIn">Number which insert into source number.</param>
        /// <param name="i">Position i.</param>
        /// <param name="j">Position j.</param>
        /// <returns>Result of inserting</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            int size = 31;

            if (i < size || i > size)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j < size || j > size)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }

            int maxValue = -1;

            maxValue = (maxValue << size) >> (size - j - 1);
            maxValue = ~((maxValue >> i) << i);
            numberIn = (numberIn << i) & maxValue;
            numberSource = (~maxValue) & numberSource;

            return numberSource | numberIn;
        }
    }
}
