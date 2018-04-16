using System;
using System.Collections;

namespace WorkWithNumbersLib
{
    public class ElementSearching
    {
        public static int BinarySearch<T>(T[]array, T numForSearching, IComparer comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{array} is null!");
            }

            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"{comparer} is null!");
            } 

            int left = 0, right = array.Length;

            while (true)
            {
                int middle = left + (right - left) / 2;

                if (comparer.Compare(array[middle], numForSearching) == 0)
                {
                    return middle;
                }

                if (comparer.Compare(array[middle], numForSearching) > 0)
                {
                    right = middle;
                }
            }

            return 0;
        }
    }
}