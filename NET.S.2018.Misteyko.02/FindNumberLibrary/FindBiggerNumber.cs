using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <param name="finishTime">The time of working of method.</param>
        /// <returns>The next bigger number contains all digits of current number</returns>
        public static int FindNextBiggerNumber(int positiveNum, out int finishTime)
        {
            Stopwatch startTime = new Stopwatch();
            startTime.Start();

            if (positiveNum == 0)
            {
                startTime.Stop();
                finishTime = TimeForMethod(startTime);
                return -1;
            }

            int copy = positiveNum;
            int[] numInArr = new int[GetSizeOfArr(copy)];

            if (numInArr.Length == 1)
            {
                startTime.Stop();
                finishTime = TimeForMethod(startTime);
                return -1;
            }

            ConvertNumToArr(numInArr, copy);

            if (numInArr.Length == 2 && numInArr[0] < numInArr[numInArr.Length - 1])
            {
                    Swap(ref numInArr[0], ref numInArr[numInArr.Length - 1]);
                startTime.Stop();
                finishTime = TimeForMethod(startTime);
                return ConvertArrToNum(numInArr);
            }

            for (int i = 0; numInArr.Length - 2 - i >= 0; i++)
            {
                if (numInArr[numInArr.Length - 1 - i] > numInArr[numInArr.Length - 2 - i])
                {
                    Swap(ref numInArr[numInArr.Length - 1 - i], ref numInArr[numInArr.Length - 2 - i]);
                    Sorts.SortHalfOfArrayByQuickSort(numInArr, numInArr.Length - 1 - i, numInArr.Length - 1);
                    startTime.Stop();
                    finishTime = TimeForMethod(startTime);
                    return ConvertArrToNum(numInArr);
                }
            }

            startTime.Stop();
            finishTime = TimeForMethod(startTime);

            return -1;
        }

        /// <summary>
        /// Swaps two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
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
            for (int i = 0; num != 0; i++)
            {
                numInArr[numInArr.Length - 1 - i] = num % 10;
                num /= 10;
            }
        }

        /// <summary>
        /// Converts the array to number.
        /// </summary>
        /// <param name="numInArr">The array wich contains the number.</param>
        /// <returns>The number.</returns>
        private static int ConvertArrToNum(int[] numInArr)
        {
            int num = numInArr[0];

            for (int i = 1; i < numInArr.Length ; i++)
            {
                num *= 10;
                num += numInArr[i];
            }

            return num;
        }
        /// <summary>
        /// Check time of working of method.
        /// </summary>
        /// <param name="startTime">Start time of method.</param>
        /// <returns>Finish time.</returns>
        private static int TimeForMethod(Stopwatch startTime)
        {
            TimeSpan finishTime = startTime.Elapsed;
            return finishTime.Milliseconds;
        }
    }
}
