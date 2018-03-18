using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkWithBitsLibrary.Tests
{
    [TestClass]
    public class BitNumbersTests
    {
        [TestMethod]
        public void ConvertNumberInBits_Convert13ToBitArray()
        {
            byte[] expected = new byte[]
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1};
            int num = 13;
            byte[] actual = BitNumbers.ConvertNumberInBits(num);
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ConvertFromBitsToInteger_ConvertABitrrayToNumber7()
        {
            byte[] actualNumberAsBits = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
            int expectedValue = 7;

            int actualValue = BitNumbers.ConvertFromBitsToInteger(actualNumberAsBits);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void InsertNumbers()
        {
            int numberSource = 15;
            int numberIn = 15;
            int i = 0;
            int j = 0;
            int expectedResult = 15;

            int actualResult = BitNumbers.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
