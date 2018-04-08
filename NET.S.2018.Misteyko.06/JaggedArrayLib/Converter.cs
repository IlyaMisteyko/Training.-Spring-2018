using System;

namespace JaggedArrayLib
{
    /// <summary>
    /// Converts delegate to interface
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Creates new delegate.
        /// </summary>
        /// <param name="del"></param>
        /// <returns>New delegate.</returns>
        public static DelegateToInterface NewDelegate(Delegate del)
        {
            return new DelegateToInterface(del);
        }

        /// <summary>
        /// Implements the interface IComparer with delegate.
        /// </summary>
        public class DelegateToInterface: IComparer
        {
            /// <summary>
            /// Field for delegate.
            /// </summary>
            private Delegate del;

            /// <summary>
            /// Constructor for initialization.
            /// </summary>
            /// <param name="del"></param>
            public DelegateToInterface(Delegate del)
            {
                this.del = del;
            }

            /// <summary>
            /// Method Compare
            /// </summary>
            /// <param name="first">First array.</param>
            /// <param name="second">Second array.</param>
            /// <returns>Result of comparing.</returns>
            public int Compare(int[] first, int[] second)
            {
                return del.Invoke(first, second);
            }
        }
    }
}