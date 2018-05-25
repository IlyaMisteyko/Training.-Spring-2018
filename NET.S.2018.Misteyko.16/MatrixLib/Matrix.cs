using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Abstract class for some matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T>
    {
        #region Fields

        /// <summary>
        /// The column of matrix.
        /// </summary>
        private readonly int column;

        /// <summary>
        /// The row of matrix.
        /// </summary>
        private readonly int row;

        /// <summary>
        /// Occurs when elements are changed.
        /// </summary>
        public event EventHandler<ChangeElementsEventArgs<T>> ChangeElements = delegate { };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <exception cref="ArgumentException">row</exception>
        public Matrix(int row, int column)
        {
            if (row <= 0 || column <= 0)
            {
                throw new ArgumentException($"{nameof(row)} or {nameof(column)} can't be negative or zero!");
            }

            this.row = row;
            this.column = column;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column => column;

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int Row => row;

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public T this[int i, int j]
        {
            get
            {
                if (i >= row || j >= column)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return GetElement(i, j);
            }
            set
            {
                if (i >= row || j >= column)
                {
                    throw new ArgumentOutOfRangeException();
                }

                SetElement(value, i, j);
            }
        }

        #endregion

        #region Methods        
        /// <summary>
        /// Raises the <see cref="E:ChangeElements" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ChangeElementsEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnChangeElements(ChangeElementsEventArgs<T> e)
        {
            EventHandler <ChangeElementsEventArgs<T>> temp = ChangeElements;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Changing elements.
        /// </summary>
        /// <param name="rowFirst">The row first.</param>
        /// <param name="columnFirst">The column first.</param>
        /// <param name="first">The first.</param>
        /// <param name="rowSecond">The row second.</param>
        /// <param name="columnSecond">The column second.</param>
        /// <param name="second">The second.</param>
        protected void Changing(int rowFirst, int columnFirst, T first, int rowSecond, int columnSecond, T second)
        {
            OnChangeElements(new ChangeElementsEventArgs<T>(rowFirst, columnFirst, first, rowSecond, columnSecond, second));
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        protected abstract T GetElement(int i, int j);

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected abstract void SetElement(T element, int i, int j);

        #endregion
    }
}
