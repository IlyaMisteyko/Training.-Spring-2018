using NUnit.Framework;
using WorkWithBitsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRootLibrary.NUnitTests
{
    [TestFixture()]
    public class BitNumbersTests
    {
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        [TestCase(14, 5, 1, 2, 10)]
        public void InsertNumberTest(int numberSource, int numberIn, int i, int j, int expected)
        {
            int actual = BitNumbers.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }
    }
}