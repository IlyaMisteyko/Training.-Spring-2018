using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfSorts
{
    /// <summary>
    /// Class of different kind of sorts
    /// </summary>
    public class Sorts
    {
        /// <summary>
        /// Method SortArrayByMergeSort
        /// Devides current array.
        /// </summary>
        /// <param name="mainArr">Array for sorting.</param>
        /// <returns>Sorted array</returns>
        public static int[] SortArrayByMergeSort(int[] mainArr)
        {
            if (mainArr == null)
            {
                throw new ArgumentNullException();
            }

            if (mainArr.Length > 1)
            {
                int[] leftArr = new int[mainArr.Length / 2];
                int[] rightArr = new int[mainArr.Length - leftArr.Length];

                for (int i = 0; i < leftArr.Length; i++)
                {
                    leftArr[i] = mainArr[i];
                }

                for (int i = 0; i < rightArr.Length; i++)
                {
                    rightArr[i] = mainArr[leftArr.Length + i];
                }

                if (leftArr.Length > 1)
                {
                    leftArr = SortArrayByMergeSort(leftArr);
                }

                if (rightArr.Length > 1)
                {
                    rightArr = SortArrayByMergeSort(rightArr);
                }

                mainArr = MergeSort(leftArr, rightArr);
            }

            return mainArr;
        }

        /// <summary>
        /// Method MergeSort
        /// Helps sort and combine array.
        /// </summary>
        /// <param name="leftArr">Takes left array.</param>
        /// <param name="rightArr">Takes right array.</param>
        /// <returns>Sorted array</returns>
        public static int[] MergeSort(int[] leftArr, int[] rightArr)
        {
            int[] sortedArr = new int[leftArr.Length + rightArr.Length];
            int left = 0, right = 0;

            for (int i = 0; i < sortedArr.Length; i++)
            {
                if (right >= rightArr.Length)
                {
                    sortedArr[i] = leftArr[left];
                    left++;
                }
                else if (left < leftArr.Length && leftArr[left] < rightArr[right])
                {
                    sortedArr[i] = leftArr[left];
                    left++;
                }
                else
                {
                    sortedArr[i] = rightArr[right];
                    right++;
                }
            }

            return sortedArr;
        }

        /// <summary>
        /// Method SortHalfOfArrayByQuickSort
        /// Sorts the half of array by quick sort.
        /// </summary>
        /// <param name="arr">Takes current array.</param>
        /// <param name="left">Takes left index of array.</param>
        /// <param name="right">Takes right index of array.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void SortHalfOfArrayByQuickSort(int[] arr, int left, int right)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            int i = left, j = right, point = arr[(right + left) / 2];

            while (i < j)
            {
                while (arr[i] < point)
                {
                    i++;
                }

                while (arr[j] > point)
                {
                    j--;
                }

                if (i < j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j && (right - left) >= 2)
            {
                SortHalfOfArrayByQuickSort(arr, left, j);

            }

            if (right > i && (right - left) >= 2)
            {
                SortHalfOfArrayByQuickSort(arr, i, right);
            }
        }

        /// <summary>
        /// Method SortArrayByQuickSort
        /// Sorts the array by quick sort.
        /// </summary>
        /// <param name="arr">Takes current array.</param>
        public static void SortArrayByQuickSort(int[] arr)
        {
            SortHalfOfArrayByQuickSort(arr, 0, arr.Length - 1);
        }
    }
}
