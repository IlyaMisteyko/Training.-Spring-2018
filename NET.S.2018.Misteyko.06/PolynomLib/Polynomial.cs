using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PolynomLib
{
    /// <summary>
    /// Represents polynom.
    /// </summary>
    public class Polynomial
    {
        private readonly double[] polynom;
        private const double eps = 0.0001;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="polynom">Array of double.</param>
        public Polynomial(double[]polynom)
        {
            if (polynom == null)
            {
                throw new ArgumentNullException($"{nameof(polynom)} is null!");
            }

            this.polynom = polynom;
        }

        /// <summary>
        /// Property which gets polynom.
        /// </summary>
        public double[] Polynom
        {
            get { return polynom; }
        }

        /// <summary>
        /// Overloaded operator "+".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="last">Second polynom.</param>
        /// <returns>Resulting polynom.</returns>
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

            double[] resultPolynom = new double[maxLength];

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

        /// <summary>
        /// Overloaded operator "+".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="num">Double number.</param>
        /// <returns>Resulting polynom.</returns>
        public static Polynomial operator +(Polynomial first, double num)
        {
            double[] resultPolynom = new double[first.polynom.Length];
            first.polynom.CopyTo(resultPolynom, 0);

            resultPolynom[0] += num;

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// Overloaded operator "+".
        /// </summary>
        /// <param name="num">Double number.</param>
        /// <param name="first">First polynom.</param>
        /// <returns>Resulting polynom.</returns>
        public static Polynomial operator +(double num, Polynomial first)
        {
            double[] resultPolynom = new double[first.polynom.Length];
            first.polynom.CopyTo(resultPolynom, 0);

            resultPolynom[0] += num;

            return new Polynomial(resultPolynom);
        }
        /// <summary>
        /// Overloaded operator "-".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="last">Second polynom.</param>
        /// <returns>Resulting polynom.</returns>
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

            double[] resultPolynom = new double[maxLength];

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

        /// <summary>
        /// Overloaded operator "-".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="num">Double number.</param>
        /// <returns>Resulting polynom.</returns>
        public static Polynomial operator -(Polynomial first, double num)
        {
            double[] resultPolynom = new double[first.polynom.Length];
            first.polynom.CopyTo(resultPolynom, 0);

            resultPolynom[0] -= num;

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// Overloaded operator "+".
        /// </summary>
        /// <param name="num">Double number.</param>
        /// <param name="first">First polynom.</param>
        /// <returns>Resulting polynom.</returns>
        public static Polynomial operator -(double num, Polynomial first)
        {
            double[] resultPolynom = new double[first.polynom.Length];
            first.polynom.CopyTo(resultPolynom, 0);

            resultPolynom[0] -= num;

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// Overloaded operator "*".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="last">Second polynom.</param>
        /// <returns>Resulting polynom.</returns>
        public static Polynomial operator *(Polynomial first, Polynomial last)
        {
            double[] resultPolynom = new double[(first.polynom.Length + last.polynom.Length) - 1];

            for (int i = 0; i < first.polynom.Length; i++)
            {
                for (int j = 0; j < last.polynom.Length; j++)
                {
                    resultPolynom[i + j] += (first.polynom[i] * last.polynom[j]);
                }
            }

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// Overloaded operator "==".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="last">Second polynom.</param>
        /// <returns>Resulting polynom.</returns>
        public static bool operator ==(Polynomial first, Polynomial last)
        {
            if (first.polynom.Length == last.polynom.Length)
            {
                for (int i = 0; i < first.polynom.Length; i++)
                {
                    if (Math.Abs(first.polynom[i] - last.polynom[i]) > eps)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Overloaded operator "!=".
        /// </summary>
        /// <param name="first">First polynom.</param>
        /// <param name="last">Second polynom.</param>
        /// <returns>Resulting polynom.</returns>
        public static bool operator !=(Polynomial first, Polynomial last)
        {
            if (first == last)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Override method "Equals".
        /// </summary>
        /// <param name="obj">Object for compare.</param>
        /// <returns>Result of equals.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial polynom = obj as Polynomial;

            if (polynom as Polynomial == null)
            {
                return false;
            }

            for (int i = 0; i < polynom.polynom.Length; i++)
            {
                if (Math.Abs(polynom.polynom[i] - polynom.polynom[i]) > eps)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override method "GetHashCode".
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < polynom.Length; i++)
            {
                hash += polynom[i].GetHashCode() * i;
            }

            return hash;
        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
