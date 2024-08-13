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
                LeftChild = new();
                RightChild = new();
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
                Insert(Root, value);
            }
        }

        private Node Insert(Node current, T value)
        {
            if (current == null) return new Node(value, false);

            if (current.LeftChild.IsRed && current.RightChild.IsRed)
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

            if(current.RightChild.IsRed)
            {
                //rotate left
            }


        }

        private Node Rotate(Node current)
        {
            Node temp = current;
            temp.LeftChild = current;
            current = temp;
        }

        private void FlipColors(Node node)
        {
            node.IsRed = !node.IsRed;
            node.LeftChild.IsRed = !node.IsRed;
            node.RightChild.IsRed = !node.IsRed;
        }

    }
}
