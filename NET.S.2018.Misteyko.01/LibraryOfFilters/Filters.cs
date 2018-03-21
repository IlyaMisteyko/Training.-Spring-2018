using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfFilters
{
    /// <summary>
    /// Class of filters
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// Filters array by digit.
        /// </summary>
        /// <param name="mainArr">The current array.</param>
        /// <param name="digit">The digit.</param>
        /// <returns>Filtered array</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static int[] FilterDigit(int[] mainArr, int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            if (mainArr == null)
            {
                throw new ArgumentNullException();
            }

            List<int> finalArr = new List<int>();

            for (int i = 0; i < mainArr.Length; i++)
            {
                int copyOfElement = mainArr[i];

                while (copyOfElement != 0)
                {
                    if (Math.Abs(copyOfElement % 10) == digit)
                    {
                        finalArr.Add(mainArr[i]);
                    }

                    copyOfElement /= 10;
                }
            }

            return finalArr.ToArray();
        }
    }
}
