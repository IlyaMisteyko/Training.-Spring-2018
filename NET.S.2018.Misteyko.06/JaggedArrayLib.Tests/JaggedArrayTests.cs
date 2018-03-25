using NUnit.Framework;
using JaggedArrayLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLib.Tests
{
    [TestFixture()]
    public class JaggedArrayTests
    {
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 2, 2 }, null, new int[] { 5 })]
        public void SortByAscendingSumOfElementsTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = new int[4][];
            actual[0] = arr4;
            actual[1] = arr3;
            actual[2] = arr2;
            actual[3] = arr1;

            int[][] expected = new int[4][];
            expected[0] = arr1;
            expected[1] = arr2;
            expected[2] = arr4;
            expected[3] = arr3;

            JaggedArray.SortByAscendingSumOfElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1, 1, 1}, new int[] {2, 2}, null, new int[] {5})]
        public void SortByDescendingSumOfElementsTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][]actual = new int[4][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;

            int[][] expected = new int[4][];
            expected[0] = arr3;
            expected[1] = arr4;
            expected[2] = arr2;
            expected[3] = arr1;

            JaggedArray.SortByDescendingSumOfElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    
        [TestCase(new int[] { 1, 6, 0, 2 }, null, new int[] { 70, 0, 0, 0 }, new int[] {-70, 4})]
        public void SortByAscendingMaxElementTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = new int[4][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;

            int[][] expected = new int[4][];
            expected[0] = arr4;
            expected[1] = arr1;
            expected[2] = arr3;
            expected[3] = arr2;

            JaggedArray.SortByAscendingMaxElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, 0, 2 }, null, new int[] { 70, 0, 0, 0 }, new int[] { -70, 4 })]
        public void SortByDescendingMaxElementTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = new int[4][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;

            int[][] expected = new int[4][];
            expected[0] = arr2;
            expected[1] = arr3;
            expected[2] = arr1;
            expected[3] = arr4;

            JaggedArray.SortByDescendingMaxElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, -16, 0, 2 }, null, new int[] { 70, 0, -100, 0 }, new int[] { -70, 4 })]
        public void SortByAscendingMinElementTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = new int[4][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;

            int[][] expected = new int[4][];
            expected[0] = arr2;
            expected[1] = arr1;
            expected[2] = arr4;
            expected[3] = arr3;

            JaggedArray.SortByAscendingMinElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, -16, 0, 2 }, null, new int[] { 70, 0, -100, 0 }, new int[] { -70, 4 })]
        public void SortByDescendingMinElementTest(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = new int[4][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;

            int[][] expected = new int[4][];
            expected[0] = arr3;
            expected[1] = arr4;
            expected[2] = arr1;
            expected[3] = arr2;

            JaggedArray.SortByDescendingMinElement(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}