using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LibraryOfFilters.DDTTests.ToArray;

namespace LibraryOfFilters.DDTTests
{
    [TestClass]
    public class FiltersTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\XMLFile.xml",
            "TestCase", DataAccessMethod.Sequential)]
        [DeploymentItem(@"LibraryOfFilters.DDTTests\XMLFile.xml")]
        [TestMethod]
        public void FilterDigitTest_FilteringArrayByDigit_ReturnFilteredArray()
        {

            int[] testArr = ToArrayConverter((TestContext.DataRow["testArr"]).ToString());
            int[] expected = ToArrayConverter((TestContext.DataRow["expected"]).ToString());

            int digit = Convert.ToInt32((TestContext.DataRow["digit"]).ToString());

            int[] actual = Filters.FilterDigit(testArr, digit);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
