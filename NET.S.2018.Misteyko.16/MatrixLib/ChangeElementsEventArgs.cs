using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// ChangeElementsEventArgs class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public sealed class ChangeElementsEventArgs<T> : EventArgs
    {
        #region Fields
        /// <summary>
        /// The row of first element.
        /// </summary>
        private readonly int rowFirst;

        /// <summary>
        /// The column of first element.
        /// </summary>
        private readonly int columnFirst;

        /// <summary>
        /// The first element.
        /// </summary>
        private readonly T first;

        /// <summary>
        /// The row of second element.
        /// </summary>
        private readonly int rowSecond;

        /// <summary>
        /// The column of second element.
        /// </summary>
        private readonly int columnSecond;

        /// <summary>
        /// The secondelement.
        /// </summary>
        private readonly T second;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeElementsEventArgs{T}"/> class.
        /// </summary>
        /// <param name="rowFirst">The row first.</param>
        /// <param name="columnFirst">The column first.</param>
        /// <param name="first">The first.</param>
        /// <param name="rowSecond">The row second.</param>
        /// <param name="columnSecond">The column second.</param>
        /// <param name="second">The second.</param>
        public ChangeElementsEventArgs(int rowFirst, int columnFirst, T first, int rowSecond, int columnSecond, T second)
        {
            this.rowFirst = rowFirst;
            this.rowSecond = rowSecond;
            this.first = first;
            this.columnFirst = columnFirst;
            this.columnSecond = columnSecond;
            this.second = second;
        }
        #endregion
    }
}
