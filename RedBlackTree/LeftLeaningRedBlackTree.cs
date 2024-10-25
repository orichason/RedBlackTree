using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    internal class LeftLeaningRedBlackTree<T> where T : IComparable<T>
    {
        internal class Node
        {
            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public bool IsRed  { get; set; }

            public bool IsLeaf => Left == null && Right == null;

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

        public LeftLeaningRedBlackTree()
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

        private Node Insert(Node node, T value)
        {
            if (node == null) return new Node(value, true);

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }

            else if(value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            else
            {
                throw new ArgumentException("An entry with the same value arleady exists");
            }


            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                // Rotate left if the red link is on the right
                node = RotateLeft(node);
            }

            if(IsRed(node.Left) && IsRed(node.Left.Left))
            {
                // Rotate right to fix two consecutive red links
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                //change colors
                FlipColors(node);
            }

            return node;
        }

        public bool Remove(T value)
        {
            int initialCount = this.Count;
            if(Root != null)
            {
                Root = Remove(Root, value);
                this.Count--;
            }

            return initialCount != this.Count;
        }

        private Node Remove(Node node, T value)
        {
            if(value.CompareTo(node.Value) < 0)
            {
                if(node.Left != null)
                {
                    if(!IsRed(node.Left) && !IsRed(node.Left.Left))
                    {

                    }
                }
            }
        }

        private Node MoveNodeLeft(Node node)
        {

        }
        private bool IsRed(Node node)
        {
            if (node == null)
                return false;
            return node.IsRed;
        }
        private Node RotateLeft(Node parent)
        {
            var newParent = parent.Right;
            var T2 = newParent.Left;

            newParent.Left = parent;
            parent.Right = T2;

            newParent.IsRed = parent.IsRed;
            parent.IsRed = true;

            return newParent;
        }

        private Node RotateRight(Node parent)
        {
            var newParent = parent.Left;
            var T2 = newParent.Right;

            newParent.Right = parent;
            parent.Left = T2;

            newParent.IsRed = parent.IsRed;
            parent.IsRed = true;

            return newParent;
        }

        private void FlipColors(Node node)
        {
            node.IsRed = !node.IsRed;
            node.Left.IsRed = !node.Left.IsRed;
            node.Right.IsRed = !node.Right.IsRed;
        }

    }
}
