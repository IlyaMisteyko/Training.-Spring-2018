using System;
using System.Collections.Generic;

namespace WorkWithNumbersLib
{
    /// <summary>
    /// Generates Fibonacci numbers.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Generator for Fibonacci numbers.
        /// </summary>
        /// <param name="sizeOfNums">The size of nums.</param>
        /// <returns>Number for Fibonacci numbers.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<int> FibonacciNumberGenerator(int sizeOfNums)
        {
            if (sizeOfNums <= 0)
            {
                throw new ArgumentException($"{sizeOfNums} can't be null or negative!");
            }

            int first = 0;
            yield return 0;

            int second = 1;
            yield return 1;

            for (int i = 2; i <= sizeOfNums; i++)
            {
                int sum = first + second;
                yield return sum;

                first = second;
                second = sum;
            }
        }
    }
}
