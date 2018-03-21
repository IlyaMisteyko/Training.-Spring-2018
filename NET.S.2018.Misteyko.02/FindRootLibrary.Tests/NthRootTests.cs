using NUnit.Framework;
using FindRootLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRootLibrary.Tests
{
    [TestFixture()]
    public class NthRootTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.001, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTest(double number, int root, double eps, double expected)
        {
            double actual = NthRoot.FindNthRoot(number, root, eps);
            Assert.AreEqual(expected, actual, eps);
        }

        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void FindNthRoot_Number_Root_Eps_ArgumentOutOfRangeException(double number, int root, double eps,
            double expected) => Assert.Throws<ArgumentOutOfRangeException>(() => NthRoot.FindNthRoot(number, root, eps));
    }
}