using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDoubleLib
{
    /// <summary>
    /// Show binary view of double.
    /// </summary>
    public class BinaryViewOfDouble
    {
        /// <summary>
        /// Convert from double to in64 bits.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>Result of converting</returns>
        public static string DoubleIn64Bits(double number)
        {
            List<int> finalList = new List<int>();

            if (number > 0)
            {
                finalList.Add(0);
            }
            else
            {
                finalList.Add(1);
            }

            number = Math.Abs(number);
            uint theIntegerPartOfNumber = (uint)number;
            double fractionPartOfNumber = number % 1;

            WorkWithIntegerPart(finalList, theIntegerPartOfNumber);
            WorkWithFraction(finalList, fractionPartOfNumber);

            return string.Join("", finalList.ToArray());
        }

        /// <summary>
        /// Work with integer part.
        /// </summary>
        /// <param name="finalList">The final list.</param>
        /// <param name="theIntegerPart">The integer part.</param>
        private static void WorkWithIntegerPart(List<int> finalList, uint theIntegerPart)
        {
            List<int> tempList = new List<int>();

            IntegerToBinary(tempList, theIntegerPart);

            CopyTo(finalList, GetExponent(tempList)); 
            CopyTo(finalList, tempList);
        }

        /// <summary>
        /// Converts integer part to binary number representation.
        /// </summary>
        /// <param name="tempList">Buffer.</param>
        /// <param name="theIntegerPart">The integer part.</param>
        private static void IntegerToBinary(List<int> tempList, uint theIntegerPart)
        {
            if (theIntegerPart == 0)
            {
                tempList.Add(0);
                return;
            }

            while (theIntegerPart != 0)
            {
                tempList.Add((int)(theIntegerPart % 2));
                theIntegerPart /= 2;
            }

            tempList.Reverse();
        }

        /// <summary>
        /// Gets exponent.
        /// </summary>
        /// <param name="tempList">Buffer.</param>
        /// <returns>Exponent part.</returns>
        private static List<int> GetExponent(List<int> tempList)
        {
            List<int> expList = new List<int>();
            int count = 0;

            foreach (int i in tempList)
            {
                if (i == 1)
                {
                    break;
                }

                count++;
            }

            IntegerToBinary(expList, (uint)(1023 + (tempList.Count - 1 - count)));
            tempList.RemoveAt(0);

            return expList; 
        }

        /// <summary>
        /// Works with fractional part.
        /// </summary>
        /// <param name="finalList">The final list.</param>
        /// <param name="fraction">Fractional part.</param>
        private static void WorkWithFraction(List<int> finalList, double fraction)
        {
            while (finalList.Count != 64)
            {
                if (fraction >= 1)
                {
                    fraction -= (int)fraction;
                }

                fraction *= 2;

                finalList.Add((int)fraction);
            }
        }

        /// <summary>
        /// Copies one list to another.
        /// </summary>
        /// <param name="finalList">The final list.</param>
        /// <param name="currentList">The current list.</param>
        private static void CopyTo(List<int> finalList, List<int> currentList)
        {
            foreach (int i in currentList)
            {
                finalList.Add(i);
            }
        }
    }
}
