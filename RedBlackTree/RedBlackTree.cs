using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    internal class RedBlackTree<T> where T : IComparable<T>
    {
        internal class Node
        {
            public T Value { get; private set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public bool IsRed  { get; set; }

            public bool IsLeaf => LeftChild == null && RightChild == null;

            public Node()
            {

            }
            public Node(T value, bool isRed)
            {
                this.Value = value;
                //LeftChild = new();
                //RightChild = new();
                this.IsRed = isRed;
            }

        }

        public Node Root { get; private set; }

        public int Count { get; private set; }

        public RedBlackTree()
        {
            Count = 0;
        }

        public void Insert(T value)
        {
            if (Count == 0)
            {
                Root = new(value, false);

            }

            else
            {
                Root = Insert(Root, value);
            }

            Root.IsRed = false;
            Count++;
        }

        private Node Insert(Node current, T value)
        {
            if (current == null) return new Node(value, true);

            if (isRed(current.LeftChild) && isRed(current.RightChild))
            {
                //change colors

                FlipColors(current);
            }

            if (value.CompareTo(current.Value) < 0)
            {
                current.LeftChild = Insert(current.LeftChild, value);
            }

            else
            {
                current.RightChild = Insert(current.RightChild, value);
            }


            if (isRed(current.RightChild) && !isRed(current.LeftChild))
            {
                //rotate left
                current = RotateLeft(current);
            }

            if(isRed(current.LeftChild) && isRed(current.LeftChild.LeftChild))
            {
                //rotate right
                current = RotateRight(current);
            }

            if (isRed(current.LeftChild) && isRed(current.RightChild))
            {
                //change colors
                FlipColors(current);
            }


            return current;
        }

        private bool isRed(Node node)
        {
            if (node == null)
                return false;
            return node.IsRed;
        }
        private Node RotateLeft(Node parent)
        {
            var newParent = parent.RightChild;
            var T2 = newParent.LeftChild;

            newParent.LeftChild = parent;
            parent.RightChild = T2;

            newParent.IsRed = parent.IsRed;
            parent.IsRed = true;

            return newParent;
        }

        private Node RotateRight(Node parent)
        {
            var newParent = parent.LeftChild;
            var T2 = newParent.RightChild;

            newParent.RightChild = parent;
            parent.LeftChild = T2;

            newParent.IsRed = parent.IsRed;
            parent.IsRed = true;

            return newParent;
        }

        private void FlipColors(Node node)
        {
            node.IsRed = !node.IsRed;
            node.LeftChild.IsRed = !node.IsRed;
            node.RightChild.IsRed = !node.IsRed;
        }

    }
}
