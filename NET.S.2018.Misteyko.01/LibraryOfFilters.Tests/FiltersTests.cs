using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryOfFilters.Tests
{
    [TestClass]
    public class FiltersTests
    {
        [TestMethod]
        public void FilterDigit_FilterArrayForPositiveNumber()
        {
            // Arrange
            int[] testArr = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] expected = { 7, 7, 70, 17 };

            // Act
            int[] actual = Filters.FilterDigit(testArr, 7);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterDigit_FilterArrayForNegativeNumber()
        {
            // Arrange
            int[] testArr = { -7, 1, -2, 3, -4, 5, 6, 7, -68, 69, -70, 15, 17 };
            int[] expected = { -7, 7, -70, 17 };

            // Act
            int[] actual = Filters.FilterDigit(testArr, 7);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_NoMatches_EmptyArray()
        {
            // Arrange
            int[] testArr = { -7, 1, -2, 3, 5, 6, 7, -68, 69, -70, 15, 17 };
            int[] expected = {  };

            // Act
            int[] actual = Filters.FilterDigit(testArr, 4);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
