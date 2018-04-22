using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib
{
    public sealed class BinarySearchTreeNode<T>
    {
        public T Node { get; }
        public BinarySearchTreeNode<T> Left { get; set; }
        public BinarySearchTreeNode<T> Right { get; set; }

        public BinarySearchTreeNode(T node)
        {
            Node = node;
            Left = null;
            Right = null;
        }

    }
}
