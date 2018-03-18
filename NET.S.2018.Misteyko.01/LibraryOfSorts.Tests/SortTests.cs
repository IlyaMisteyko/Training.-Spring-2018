using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryOfSorts;

namespace LibraryOfSorts.Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void SortArrayByQuickSort_SortingOfPositiveArrayByQuickSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 3, 1, 5, 2, 7, 19, 34, 11, 56 };
            int[] expected = new int[] { 1, 2, 3, 5, 7, 11, 19, 34, 56 };

            // Act
            Sorts.SortArrayByQuickSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortArrayByQuickSort_SortingOfNegativeArrayByQuickSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { -3, -1, -5, -2, -7, -19, -34, -11, -56 };
            int[] expected = new int[] { -56, -34, -19, -11, -7, -5, -3, -2, -1 };

            // Act
            Sorts.SortArrayByQuickSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortArrayByQuickSort_SortingOfMixedArrayByQuickSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 3, -1, -5, -2, 7, -19, 34, -11, 56 };
            int[] expected = new int[] { -19, -11, -5, -2, -1, 3, 7, 34, 56 }; 

            // Act
            Sorts.SortArrayByQuickSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortHalfOfArrayByQuickSort_SortingOfPositiveArrayByQuickSort_ReturnHalfSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 4, 4, 3, 2, 1, 0, 0 };
            int[] expected = new int[] { 4, 4, 1, 2, 3, 0, 0 };

            // Act
            Sorts.SortHalfOfArrayByQuickSort(actual, 2, 4);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortHalfOfArrayByQuickSort_SortingOfNegativeArrayByQuickSort_ReturnHalfSortedArray()
        {
            // Arrange
            int[] actual = new int[] { -4, -15, -7, -76, -23, -20, -2 };
            int[] expected = new int[] { -4, -15, -76, -23, -7, -20, -2 };

            // Act
            Sorts.SortHalfOfArrayByQuickSort(actual, 2, 4);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortHalfOfArrayByQuickSort_SortingOfMixedArrayByQuickSort_ReturnHalfSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 4, -15, -7, 76, -23, 20, -2 };
            int[] expected = new int[] { 4, -15, -23, -7, 76, 20, -2 };

            // Act
            Sorts.SortHalfOfArrayByQuickSort(actual, 2, 4);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SortArrayByMergeSort_SortingOfPositiveArrayByMergeSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 3, 1, 5, 2, 7, 19, 34, 11, 56 };
            int[] expected = new int[] { 1, 2, 3, 5, 7, 11, 19, 34, 56 };

            // Act
            actual = Sorts.SortArrayByMergeSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortArrayByMergeSort_SortingOfNegativeArrayByMergeSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { -3, -1, -5, -2, -7, -19, -34, -11, -56 };
            int[] expected = new int[] { -56, -34, -19, -11, -7, -5, -3, -2, -1 };

            // Act
            actual = Sorts.SortArrayByMergeSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortArrayByMergeSort_SortingOfMixedArrayByMergeSort_ReturnSortedArray()
        {
            // Arrange
            int[] actual = new int[] { 3, -1, -5, -2, 7, -19, 34, -11, 56 };
            int[] expected = new int[] { -19, -11, -5, -2, -1, 3, 7, 34, 56 };

            // Act
            actual = Sorts.SortArrayByMergeSort(actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
