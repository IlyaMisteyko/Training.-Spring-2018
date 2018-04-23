using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Calculator
    {
        IAveragingMethod averagingMethod;

        public Calculator(IAveragingMethod averagingMethod)
        {
            if (ReferenceEquals(averagingMethod, null))
            {
                throw new ArgumentNullException(nameof(averagingMethod));
            }

            this.averagingMethod = averagingMethod;
        }

        public double CalculateAverage(List<double> values, IAveragingMethod averagingMethod)
        {
            if (values == null)
            {
                throw  new ArgumentNullException(nameof(values));
            }

            return averagingMethod.CalculateAverage(values);
        }

        public double CalculateAverageByDelegate(List<double> values, Func<List<double>, double> del)
        {
            if (ReferenceEquals(del, null))
            {
                throw new ArgumentNullException(nameof(del));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return del(values);
        }
    }
}
