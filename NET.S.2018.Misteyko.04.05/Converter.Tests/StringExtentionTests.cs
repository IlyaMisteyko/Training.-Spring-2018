using NUnit.Framework;
using Converter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Tests
{
    [TestFixture()]
    public class StringExtentionTests
    {
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2, 62370570)]

        //[TestCase("11111111111111111111111111111111" для основания 2->OverflowException)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        [TestCase("10", 5, 5)]
        public void ToDecimalConverterTest(string source, int basis, int expected)
        {
            Notation n = new Notation(basis);
            int actual = source.ToDecimalConverter(n);
            Assert.AreEqual(expected, actual);
        }

        //[TestCase("1AeF101", 2)]
        //[TestCase("SA123", 2)]
        //[TestCase("764241", 20)]
        //public void TestsOfArgumentException(string source, int basis)
        //{
        //    Notation n = new Notation(basis);
        //    Assert.Throws<System.ArgumentException>(() => source.ToDecimalConverter(n));
        //}
    }
}