using NUnit.Framework;
using LibraryOfFilters;

namespace LibraryOfFilters.NUnitTests
{
    /// <summary>
    /// Testing of filters with NUnit
    /// </summary>
    [TestFixture]
    public class FiltersNUnitTests
    {

        /// <summary>
        /// Testing of "FilterDigitTest" method.
        /// </summary>
        /// <param name="testArr">The test arr.</param>
        /// <param name="expected">The expected array.</param>
        /// <param name="digit">The digit.</param>
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new int[] { 7, 7, 70, 17 }, 7)]
        [TestCase(new int[] { -7, 1, -2, 3, -4, 5, 6, 7, -68, 69, -70, 15, 17 }, new int[] { -7, 7, -70, 17 }, 7)]
        [TestCase(new int[] { -7, 1, -2, 3, 5, 6, 7, -68, 69, -70, 15, 17 }, new int[] { }, 4)]
        public void FilterDigitTest(int[] testArr, int[] expected, int digit)
        {
            int[] actual = Filters.FilterDigit(testArr, digit);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}