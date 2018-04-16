using System;
using System.Collections;

namespace WorkWithNumbersLib
{
    /// <summary>
    /// Collection Queue
    /// </summary>
    /// <typeparam name="T">Param T.</typeparam>
    /// <seealso cref="System.Collections.IEnumerable" />
    public class Queue<T> : IEnumerable
    {
        #region Fields
        /// <summary>
        /// The default size of the array.
        /// </summary>
        private const int defaultSize = 4;

        /// <summary>
        /// The array.
        /// </summary>
        private T[] array;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.array = new T[defaultSize];
            this.Count = 0;
            this.Version = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="size">Size of queue.</param>
        /// <exception cref="ArgumentException">size of queue.</exception>
        public Queue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException($"{nameof(size)} can't be negative!");
            }

            this.array = new T[size];
            this.Count = 0;
            this.Version = 1;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the count of queue.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        private int Version { get; set; }

        /// <summary>
        /// Gets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>Element of array.</returns>
        public T this[int index]
        {
            get
            {
                return this.array[index];
            }
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>Dequeues value.</returns>
        public T Dequeue()
        {
            T temp = this.array[this.Count - 1];
            this.array[this.Count - 1] = default(T);

            return temp;
        }

        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if (this.Count == this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length + 2);
            }

            T[] temp = new T[this.array.Length];
            temp[0] = item;

            for (int i = 0; i < this.Count; i++)
            {
                temp[i + 1] = this.array[i];
            }

            this.array = temp;
            this.Count++;
        }

        /// <summary>
        /// Peeks head of this instance.
        /// </summary>
        /// <returns>Head of the instance.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.array[this.Count - 1];
        }
        #endregion

        #region Iterator        
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }
        #endregion
    }

    /// <summary>
    /// Iterator for a queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.IEnumerator" />
    public class QueueIterator<T> : IEnumerator
    {
        #region Fields
        /// <summary>
        /// The queue
        /// </summary>
        private Queue<T> queue;

        /// <summary>
        /// The position in the queue.
        /// </summary>
        private int position;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIterator{T}"/> class.
        /// </summary>
        /// <param name="queue">The queue.</param>
        public QueueIterator(Queue<T> queue)
        {
            this.queue = queue;
            this.position = -1;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public object Current
        {
            get
            {
                if (this.position == -1 || this.position == this.queue.Count)
                {
                    throw new InvalidOperationException();
                }

                return this.queue[position];
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (this.position != this.queue.Count)
            {
                this.position++;
            }

            return this.position < this.queue.Count;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }
        #endregion
    }
}