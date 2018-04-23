using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class Generator<T>
    {
        public IEnumerable<T> GeneratorOfNumbers(int size, T first, T second, Func<T, T, T> del)
        {
            yield return first;
            yield return second;

            for (int i = 2; i <= size; i++)
            {
                T result = del(first, second);

                yield return result;

                first = second;
                second = result;
            }
        }
    }
}
