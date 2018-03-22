using NUnit.Framework;
using AlgorithmsOfFindingGCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsOfFindingGCD.Tests
{
    [TestFixture()]
    public class AlgorithmsTests
    {
        [TestCase(255, 45, 35, 25, 5, 5)]
        [TestCase(1, -1, 1, 1, -1, 1)]
        [TestCase(36, 37, 38, 39, 40, 1)]
        [TestCase(-6, -9, -12, -15, -21, 3)]
        [TestCase(14, 7, 0, 49, 21, 7)]
        public void EuclideanAlgorithmTest(int first, int second, int third, int fourth, int fifth, int expected)
        {
            int actual = Algorithms.FindGcdWithEuclideanAlgorithm(first, second, third, fourth, fifth);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(255, 45, 35, 25, 5, 5, 5)]
        [TestCase(1, -1, 1, 1, -1, 1, 1)]
        [TestCase(36, 37, 38, 39, 40, 41, 1)]
        [TestCase(-6, -9, -12, -15, -21, -27, 3)]
        [TestCase(14, 7, 0, 49, 21, 70, 7)]
        public void SteinsAlgorithmTest(int first, int second, int third, int fourth, int fifth, int sixth, int expected)
        {
            int actual = Algorithms.FindGcdWithSteinsAlgorithm(first, second, third, fourth, fifth, sixth);

            Assert.AreEqual(expected, actual);
        }
    }
}