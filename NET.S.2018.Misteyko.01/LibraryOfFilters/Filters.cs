using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfFilters
{
    /// <summary>
    /// Interface for filter
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Search digit in number.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Result of searching.</returns>
        bool Contain(int item);
    }

    /// <summary>
    /// Filter for digit
    /// </summary>
    public class FilterDigit : IFilter 
    {
        /// <summary>
        /// Digit for searching.
        /// </summary>
        private readonly int digit;

        /// <summary>
        /// Ctor which initializes of field for digit.
        /// </summary>
        /// <param name="digit"></param>
        public FilterDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            this.digit= digit;
        }

        /// <summary>
        /// Search digit in number.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Result of searching.</returns>
        public bool Contain(int element)
        {
            while (element != 0)
            {
                if (Math.Abs(element % 10) == this.digit)
                {
                    return true;
                }

                element /= 10;
            }

            return false;
        }
    }

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
        public static int[] FilterDigit(int[] mainArr, IFilter digit)
        {
            if (mainArr == null)
            {
                throw new ArgumentNullException();
            }

            List<int> finalArr = new List<int>();

            for (int i = 0; i < mainArr.Length; i++)
            {
                if (digit.Contain(mainArr[i]))
                {
                    finalArr.Add(mainArr[i]);
                }
            }

            return finalArr.ToArray();
        }
    }
}
