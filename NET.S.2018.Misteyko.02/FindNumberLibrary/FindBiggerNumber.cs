using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfSorts;

namespace FindNumberLibrary
{
    /// <summary>
    /// Find number bigger than current
    /// </summary>
    public class FindBiggerNumber
    {
        /// <summary>
        /// Finds the next bigger number.
        /// </summary>
        /// <param name="positiveNum">The positive number.</param>
        /// <returns>The next bigger number contains all digits of current number</returns>
        public static int FindNextBiggerNumber(int positiveNum)
        {
            if (positiveNum == 0)
            {
                return -1;
            }

            int copy = positiveNum;
            int[] numInArr = new int[GetSizeOfArr(copy)];

            ConvertNumToArr(numInArr, copy);

            if (numInArr.Length == 1)
            {
                return -1;
            }
            else if (numInArr.Length == 2)
            {
                if (numInArr[0] < numInArr[numInArr.Length - 1])
                {
                    ChangeToBiggerNumber(numInArr, 0);
                    return ConvertArrToNum(numInArr);
                }
                else
                {
                    return -1;
                }
            }
            else 
            {
                for (int i = 0; ; i++)
                {
                    if (numInArr[numInArr.Length - 1 - i] > numInArr[numInArr.Length - 2 - i])
                    {
                        ChangeToBiggerNumber(numInArr, i);
                        Sorts.SortHalfOfArrayByQuickSort(numInArr, numInArr.Length - 1 - i, numInArr.Length - 1);
                        return ConvertArrToNum(numInArr);
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// Changes elements in array.
        /// </summary>
        /// <param name="numInArr">Number converting in array.</param>
        /// <param name="i">Iterator.</param>
        private static void ChangeToBiggerNumber(int[] numInArr, int i)
        {
            int temp = numInArr[numInArr.Length - 1 - i];
            numInArr[numInArr.Length - 1 - i] = numInArr[numInArr.Length - 2 - i];
            numInArr[numInArr.Length - 2 - i] = temp;
        }

        /// <summary>
        /// Gets the size of array.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>Size of array.</returns>
        private static int GetSizeOfArr(int num)
        {
            int size = 0;

            while (num != 0)
            {
                num /= 10;
                size++;
            }

            return size;
        }

        /// <summary>
        /// Converts the number to array.
        /// </summary>
        /// <param name="numInArr">The array for number.</param>
        /// <param name="num">The number.</param>
        private static void ConvertNumToArr(int[] numInArr, int num)
        {
            for (int i = 0; ; i++)
            {
                numInArr[numInArr.Length - 1 - i] = num % 10;
                num /= 10;

                if (num == 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Converts the array to number.
        /// </summary>
        /// <param name="numInArr">The array wich contains the number.</param>
        /// <returns>The number.</returns>
        private static int ConvertArrToNum(int[] numInArr)
        {
            int num = 0;

            for (int i = 0, j = numInArr.Length - 1; i < numInArr.Length ; i++, j--)
            {
                num += numInArr[i] * (int)Math.Pow(10, j);
            }

            return num;
        }
    }
}
