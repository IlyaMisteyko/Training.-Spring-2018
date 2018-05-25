using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Diagonal matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MatrixLib.SquareMatrix{T}" />
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Fields        
        /// <summary>
        /// The diagonal matrix.
        /// </summary>
        private T[] diagonal;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentException">size</exception>
        public DiagonalMatrix(int size) : base(size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} can't be negative or zero!");
            }

            diagonal = new T[size];
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        protected override T GetElement(int i, int j)
        {
            if (i != j)
            {
                return default(T);
            }

            return diagonal[i];
        }

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void SetElement(T element, int i, int j)
        {
            if (i != j)
            {
                return;
            }

            diagonal[i] = element;
        }
        #endregion
    }
}
