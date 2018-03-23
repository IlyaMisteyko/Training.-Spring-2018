using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkWithBitsLibrary.Tests
{
    [TestClass]
    public class BitNumbersTests
    {
        [TestMethod]
        public void InsertNumber_Insert15Into15WhenI0J0_15()
        {
            int numberSource = 15;
            int numberIn = 15;
            int i = 0;
            int j = 0;
            int expectedResult = 15;

            int actualResult = BitNumbers.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNumber_Insert15Into8WhenI0J0_9()
        {
            int numberSource = 8;
            int numberIn = 15;
            int i = 0;
            int j = 0;
            int expectedResult = 9;

            int actualResult = BitNumbers.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNumber_Insert15Into8WhenI3J8_120()
        {
            int numberSource = 8;
            int numberIn = 15;
            int i = 3;
            int j = 8;
            int expectedResult = 120;

            int actualResult = BitNumbers.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
