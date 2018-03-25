using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLib
{
    /// <summary>
    /// Class which work with jagged array.
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// Sorting jagged array by the ascending sum of elements with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByAscendingSumOfElements(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (SumOfElements(jaggedArr[j]) > SumOfElements(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting jagged array by the descending sum of elements with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByDescendingSumOfElements(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (SumOfElements(jaggedArr[j]) < SumOfElements(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting jagged array by the ascending max element with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByAscendingMaxElement(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (FindMaxValue(jaggedArr[j]) > FindMaxValue(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting jagged array by the descending max element with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByDescendingMaxElement(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (FindMaxValue(jaggedArr[j]) < FindMaxValue(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting jagged array by the ascending min element with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByAscendingMinElement(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (FindMinValue(jaggedArr[j]) < FindMinValue(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting jagged array by the descending min element with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <exception cref="System.ArgumentNullException">jagged arr</exception>
        public static void SortByDescendingMinElement(int[][] jaggedArr)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"Array {nameof(jaggedArr)} is null!");
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (FindMinValue(jaggedArr[j]) > FindMinValue(jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Finds maximum element of array.
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <returns>Max element</returns>
        private static int FindMaxValue(int[] arr)
        {
            if (arr == null)
            {
                return int.MaxValue;
            }

            int[] tempArr = arr;

            int max = tempArr[0];

            for (int i = 1; i < tempArr.Length; i++)
            {
                if (max < tempArr[i])
                {
                    max = tempArr[i];
                }
            }

            return max;
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
