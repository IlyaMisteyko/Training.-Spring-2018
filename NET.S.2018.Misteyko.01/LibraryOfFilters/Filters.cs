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
        public static int[] FilterDigit(int[] mainArr, int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            int[] finalArr = new int[0];

            for (int i = 0; i < mainArr.Length; i++)
            {
                int copyOfElement = mainArr[i];

                for (; ; copyOfElement /= 10)
                {
                    int temp = copyOfElement % 10;

                    if (Math.Abs(temp) == digit)
                    {
                        int[] tempArr = finalArr;
                        finalArr = new int[tempArr.Length + 1];

                        for (int j = 0; j < tempArr.Length; j++)
                        {
                            finalArr[j] = tempArr[j];
                        }

                        finalArr[finalArr.Length - 1] = mainArr[i];

                        break;
                    }

                    if ( copyOfElement == 0)
                    {
                        break;
                    }
                }
            }

            return finalArr;
        }
    }
}
