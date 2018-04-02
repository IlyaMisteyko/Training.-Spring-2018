using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLib
{
    /// <summary>
    /// Comparer interface.
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares first first array with second.
        /// </summary>
        /// <param name="first">The first array.</param>
        /// <param name="second">The second array.</param>
        /// <returns> Result of comparing.</returns>
        int Compare(int[] first, int[] second);
    }

    /// <summary>
    /// Class which work with jagged array.
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// Sort of jagged array with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public static void BubbleSort(int[][] jaggedArr, IComparer compare)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"{jaggedArr} is null!");
            }

            if (compare == null)
            {
                throw new ArgumentNullException($"{compare} is null!");
            }

            bool flag = true;
            int i = jaggedArr.Length - 1;

            while (flag)
            {
                flag = false;
                for (int j = 0; j < i; i++)
                {
                    if (compare.Compare(jaggedArr[j], jaggedArr[j + 1]) > 0)
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                        flag = true;
                    }
                }

                i--;
            }
        }

        /// <summary>
        /// Finds minimum element of array.
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <returns>Min element</returns>
        private static int FindMinValue(int[] arr)
        {
            if (arr == null)
            {
                return int.MaxValue;
            }

            int[] tempArr = arr;
            int min = tempArr[0];

            for (int i = 1; i < tempArr.Length; i++)
            {
                if (min > tempArr[i])
                {
                    min = tempArr[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Sum of elements of array.
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <returns>Sum of array.</returns>
        private static int SumOfElements(int[] arr)
        {
            if (arr == null)
            {
                return int.MaxValue;
            }

            int sum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        /// <summary>
        /// Swaps arrays.
        /// </summary>
        /// <param name="a">The first array.</param>
        /// <param name="b">The second array.</param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
    }
}
