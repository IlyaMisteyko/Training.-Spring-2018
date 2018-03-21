using NUnit.Framework;
using FindNumberLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberLibrary.Tests
{
    [TestFixture()]
    public class FindBiggerNumberTests
    {
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumberTest(int num, int expect)
        {
            int timeForMethod = 0;
            num = FindBiggerNumber.FindNextBiggerNumber(num, out timeForMethod);
            Assert.AreEqual(expect, num);
        }
    }
}