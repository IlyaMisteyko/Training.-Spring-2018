using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomLib
{
    public class Polynomial
    {
        private readonly int[] polynom;

        public Polynomial(int[]polynom)
        {
            if (polynom == null)
            {
                throw new ArgumentNullException($"{nameof(polynom)} is null!");
            }

            this.polynom = polynom;
        }

        public static Polynomial operator +(Polynomial first, Polynomial last)
        {
            bool firstMax = first.polynom.Length > last.polynom.Length;
            int maxLength = 0;
            int minLength = 0;

            if (firstMax == true)
            {
                maxLength = first.polynom.Length;
                minLength = last.polynom.Length;
            }
            else
            {
                maxLength = last.polynom.Length;
                minLength = first.polynom.Length;
            }

            int[] resultPolynom = new int[maxLength];

            if (firstMax == true)
            {
                first.polynom.CopyTo(resultPolynom, 0);
            }
            else
            {
                last.polynom.CopyTo(resultPolynom, 0);
            }

            for (int i = 0; i < minLength; i++)
            {
                if (firstMax == true)
                {
                    resultPolynom[i] += last.polynom[i];
                }
                else
                {
                    resultPolynom[i] += first.polynom[i];
                }
            }

            return new Polynomial(resultPolynom);
        }

        public static Polynomial operator -(Polynomial first, Polynomial last)
        {
            bool firstMax = first.polynom.Length > last.polynom.Length;
            int maxLength = 0;
            int minLength = 0;

            if (firstMax == true)
            {
                maxLength = first.polynom.Length;
                minLength = last.polynom.Length;
            }
            else
            {
                maxLength = last.polynom.Length;
                minLength = first.polynom.Length;
            }

            int[] resultPolynom = new int[maxLength];

            if (firstMax == true)
            {
                first.polynom.CopyTo(resultPolynom, 0);
            }
            else
            {
                last.polynom.CopyTo(resultPolynom, 0);
            }

            for (int i = 0; i < minLength; i++)
            {
                if (firstMax == true)
                {
                    resultPolynom[i] -= last.polynom[i];
                }
                else
                {
                    resultPolynom[i] -= first.polynom[i];
                }
            }

            return new Polynomial(resultPolynom);
        }
    }
}
