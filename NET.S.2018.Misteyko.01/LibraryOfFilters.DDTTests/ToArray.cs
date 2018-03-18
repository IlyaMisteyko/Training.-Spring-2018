using System;
using System.Collections.Generic;

namespace LibraryOfFilters.DDTTests
{
    /// <summary>
    /// Class for converting
    /// </summary>
    public class ToArray
    {
        /// <summary>
        /// Converter to array.
        /// </summary>
        /// <param name="convertingString">The converting string.</param>
        /// <returns>Converted string</returns>
        public static int[] ToArrayConverter(string convertingString)
        {
            if (convertingString.Length != 0)
            {
                string[] convertable = convertingString.Split(',');

                List<int> convertingNums = new List<int>();

                for (int i = 0; i < convertable.Length; i++)
                {
                    convertingNums.Add(Convert.ToInt32(convertable[i]));
                }

                return convertingNums.ToArray();
            }

            return new int[] { };
        }
    }
}
