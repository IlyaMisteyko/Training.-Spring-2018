using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeLib
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Fields

        private BinarySearchTreeNode<T> root;
        private IComparer<T> comparer;

        #endregion

        #region Constructors

        public BinarySearchTree()
        {
            root = null;
            comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                this.comparer = Comparer<T>.Default;
            }

            this.comparer = comparer;
        }

        #endregion

        #region Properties

        public int Count { get; private set; }

        #endregion

        #region Methods

        public void Insert(T item)
        {
            if (ReferenceEquals(root, null))
            {
                root = new BinarySearchTreeNode<T>(item);
                Count++;
                return;
            }

            Insert(root, item);
        }

        private void Insert(BinarySearchTreeNode<T> root, T item)
        {
            if (comparer.Compare(root.Node, item) > 0)
            {
                if (ReferenceEquals(root.Left, null))
                {
                    BinarySearchTreeNode<T> input = new BinarySearchTreeNode<T>(item);
                    root.Left = input;
                    Count++;
                }
                else
                {
                    Insert(root.Left, item);
                }
            }
            else if (comparer.Compare(root.Node, item) < 0 || comparer.Compare(root.Node, item) == 0)
            {
                if (ReferenceEquals(root.Right, null))
                {
                    BinarySearchTreeNode<T> input = new BinarySearchTreeNode<T>(item);
                    root.Right = input;
                    Count++;
                }
                else
                {
                    Insert(root.Right, item);
                }
            }
        }

        public BinarySearchTreeNode<T> Find(T item)
        {
            if (ReferenceEquals(root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return Find(root, item);
        }

        private BinarySearchTreeNode<T> Find(BinarySearchTreeNode<T> root, T item)
        {
            if (ReferenceEquals(root, null))
            {
                return null;
            }

            if (comparer.Compare(root.Node, item) == 0)
            {
                return root;
            }

            if (comparer.Compare(root.Node, item) > 0)
            {
                return Find(root.Left, item);
            }

            return Find(root.Right, item);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumarable<T> methods

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrder()
        {
            if (ReferenceEquals(root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return PreOrder(root);
        }

        private IEnumerable<T> PreOrder(BinarySearchTreeNode<T> root)
        {
            yield return root.Node;

            foreach (var item in PreOrder(root.Left))
            {
                yield return item;
            }

            foreach (var item in PreOrder(root.Right))
            {
                yield return item;
            }
        }

        public IEnumerable<T> InOrder()
        {
            if (ReferenceEquals(root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return InOrder(root);
        }

        private IEnumerable<T> InOrder(BinarySearchTreeNode<T> root)
        {
            foreach (var item in PreOrder(root.Left))
            {
                yield return item;
            }

            yield return root.Node;

            foreach (var item in PreOrder(root.Right))
            {
                yield return item;
            }
        }

        public IEnumerable<T> PostOrder()
        {
            if (ReferenceEquals(root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return PostOrder(root);
        }

        private IEnumerable<T> PostOrder(BinarySearchTreeNode<T> root)
        { 
            foreach (var item in PreOrder(root.Left))
            {
                yield return item;
            }

            foreach (var item in PreOrder(root.Right))
            {
                yield return item;
            }

            yield return root.Node;
        }

        #endregion
    }
}
