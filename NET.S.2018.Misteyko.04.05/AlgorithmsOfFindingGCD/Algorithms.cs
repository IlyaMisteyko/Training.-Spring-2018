using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsOfFindingGCD
{
    /// <summary>
    /// Algorithms for finding GCD.
    /// </summary>
    public class Algorithms
    {
        /// <summary>
        /// Finds GCD with euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers for finding GCD.</param>
        /// <returns>G C D.</returns>
        public static int FindGcdWithEuclideanAlgorithm(params int[] numbers)
        {
            int gcd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = EuclideanAlgorithm(Math.Abs(gcd), Math.Abs(numbers[i]));
            }

            return gcd;
        }

        /// <summary>
        /// Euclideans algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>GCD of a and b</returns>
        public static int EuclideanAlgorithm(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Finds the GCD with steins algorithm.
        /// </summary>
        /// <param name="numbers">Numbers for finding GCD.</param>
        /// <returns>G C D.</returns>
        public static int FindGcdWithSteinsAlgorithm(params int[] numbers)
        {
            int gcd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = SteinsAlgorithm(Math.Abs(gcd), Math.Abs(numbers[i]));
            }

            return gcd;
        }

        /// <summary>
        /// Steinse's algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>GCD of a and b.</returns>
        public static int SteinsAlgorithm(int a, int b)
        {
            int k = 1;

            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                while ((a % 2 == 0) && (b % 2 != 0))
                {
                    a /= 2;
                }

                while ((b % 2 == 0) && (a % 2 != 0))
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * k;
        }
    }
}
