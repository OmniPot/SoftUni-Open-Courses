namespace AvlTreeLab
{
    using System;
    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public int BalanceFactor { get; set; }

        // Helper properties
        public bool isLeftChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this == this.Parent.LeftChild;
            }
        }

        public bool isRightChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this == this.Parent.RightChild;
            }
        }

        public bool ChildrenCount
        {
            get
            {
                // TODO
                return false;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}