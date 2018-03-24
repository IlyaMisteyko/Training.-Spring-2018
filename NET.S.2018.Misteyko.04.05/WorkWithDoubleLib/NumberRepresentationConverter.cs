using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDoubleLib
{
    /// <summary>
    /// Show binary view of double.
    /// </summary>
    public static class NumberRepresentationConverter
    {
        /// <summary>
        /// Size of bits in byte.
        /// </summary>
        private const int BITS_IN_BYTE = 8;

        /// <summary>
        /// Converts from double to in64 bits string.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>Result of converting</returns>
        public static string DoubleToBinaryString(double number)
        {
            int markOne = 1, markZero = 0;
            string numberInBits = null;
            DoubleToLongStruct doubleToLong = new DoubleToLongStruct();
            doubleToLong.Double64bits = number;
            long asDouble = doubleToLong.Long64bits;

            for (int i = 0; i < BITS_IN_BYTE * BITS_IN_BYTE; i++)
            {
                if ((asDouble & markOne) == markOne)
                {
                    numberInBits += markOne.ToString();
                }
                else
                {
                    numberInBits += markZero.ToString();
                }

                asDouble >>= 1;
            }

            return Reverse(numberInBits);
        }

        /// <summary>
        /// Reverses string.
        /// </summary>
        /// <param name="numberInBits">String of number.</param>
        /// <returns>Reversed string</returns>
        private static string Reverse(string numberInBits)
        { 
            string s = string.Empty;

            for (int i = numberInBits.Length - 1; i >= 0; i--)
            {
                s += numberInBits[i];
            }

            return s;
        }

        /// <summary>
        /// Struct which contain field for double and long
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            /// <summary>
            /// Field for long
            /// </summary>
            [FieldOffset(0)]
            private readonly long long64bits;

            /// <summary>
            /// Field for double
            /// </summary>
            [FieldOffset(0)]
            private double double64bits;

            /// <summary>
            /// Sets value of double.
            /// </summary>
            /// <value>
            /// Double number.
            /// </value>
            public double Double64bits
            {
                set
                {
                    this.double64bits = value;
                }
            }

            /// <summary>
            /// Gets the value of long.
            /// </summary>
            /// <value>
            /// Long number.
            /// </value>
            public long Long64bits
            {
                get
                {
                    return this.long64bits;
                }
            }
        }
    }
}
