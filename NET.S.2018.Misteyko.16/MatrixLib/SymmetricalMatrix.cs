using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Symmetrical matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MatrixLib.SquareMatrix{T}" />
    class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        #region Fields        
        /// <summary>
        /// The symmetrical matrix
        /// </summary>
        private T[,] symmetrical;

        /// <summary>
        /// The state of symmetrical matrix.
        /// </summary>
        private bool isSymmetrical;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentException">size</exception>
        public SymmetricalMatrix(int size) : base(size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} can't be negative or zero!");
            }

            isSymmetrical = false;
            symmetrical = new T[size, size];
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Determines whether the specified matrix is symmetrical.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <c>true</c> if the specified matrix is symmetrical; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSymmetrical(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!matrix[i, j].Equals(matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            isSymmetrical = true;
            return true;
        }
        #endregion
    }
}
