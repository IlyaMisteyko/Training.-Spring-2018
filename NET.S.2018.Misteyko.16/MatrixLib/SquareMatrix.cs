using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Square matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MatrixLib.Matrix{T}" />
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Fields        
        /// <summary>
        /// The square matrix.
        /// </summary>
        private T[,] square;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentException">size</exception>
        public SquareMatrix(int size) : base(size, size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} can't be negative or zero!");
            }
            square = new T[size, size];
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
            return square[i, j];
        }

        /// <summary>
        /// Sets the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void SetElement(T element, int i, int j)
        {
            square[i, j] = element;
        }
        #endregion
    }
}
