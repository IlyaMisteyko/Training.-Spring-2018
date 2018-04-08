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
    /// Delegate for comparing.
    /// </summary>
    /// <param name="first">First array.</param>
    /// <param name="last">Last array.</param>
    /// <returns></returns>
    public delegate int Delegate(int[] first, int[] last);

    /// <summary>
    /// Class which work with jagged array.
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// Sorts with the interface.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <param name="compare">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public static void SortWithInterface(int[][] jaggedArr, IComparer compare)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"{jaggedArr} is null!");
            }

            if (compare == null)
            {
                throw new ArgumentNullException($"{compare} is null!");
            }

            BubbleSort(jaggedArr, compare);
        }

        /// <summary>
        /// Sorts with the delegate.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <param name="del">The delegate.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public static void SortWithDelegate(int[][] jaggedArr, Delegate del)
        {
            if (jaggedArr == null)
            {
                throw new ArgumentNullException($"{jaggedArr} is null!");
            }

            if (del == null)
            {
                throw new ArgumentNullException($"{del} is null!");
            }

            BubbleSort(jaggedArr, Converter.NewDelegate(del));
        }

        /// <summary>
        /// Sort of jagged array with bubble sort.
        /// </summary>
        /// <param name="jaggedArr">The jagged array.</param>
        /// <param name="compare">The compare.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        private static void BubbleSort(int[][] jaggedArr, IComparer compare)
        {
            bool flag = true;
            int i = jaggedArr.Length - 1;

            while (flag)
            {
                flag = false;
                for (int j = 0; j < i; j++)
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
