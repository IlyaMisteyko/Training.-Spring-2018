using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRootLibrary
{
    public class NthRoot
    {
        public static double FindNthRoot(double number, int root, double eps)
        {
            if (root % 2 == 0 && number < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (eps < 0 || eps > 1)
            {
                throw new ArgumentOutOfRangeException("");
            }

            double x0 = number / root;
            double x1 = (1.0 / root) * ((root - 1) * x0 + number / Math.Pow(x0, (root - 1)));

            while (Math.Abs(x1 - x0) >= eps)
            {
                x0 = x1;
                x1 = (1.0 / root) * ((root - 1) * x0 + number / Math.Pow(x0, (root - 1)));

            }

            return x1;
        }
    }
}
