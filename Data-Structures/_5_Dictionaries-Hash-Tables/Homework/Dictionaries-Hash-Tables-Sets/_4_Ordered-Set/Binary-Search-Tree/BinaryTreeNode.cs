namespace _4_Ordered_Set
{
    using System;

    public class BinaryTreeNode<T>
        where T : IComparable
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public virtual T Value { get; set; }

        public virtual BinaryTreeNode<T> LeftChild { get; set; }

        public virtual BinaryTreeNode<T> RightChild { get; set; }

        public virtual BinaryTreeNode<T> Parent { get; set; }

        public virtual BinaryTree<T> Tree { get; set; }

        public virtual bool IsLeaf
        {
            get { return this.ChildCount == 0; }
        }

        public virtual bool IsInternal
        {
            get { return this.ChildCount > 0; }
        }

        public virtual bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.LeftChild == this; }
        }

        public virtual bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.RightChild == this; }
        }

        public virtual int ChildCount
        {
            get
            {
                var count = 0;

                if (this.LeftChild != null)
                {
                    count++;
                }

                if (this.RightChild != null)
                {
                    count++;
                }

                return count;
            }
        }

        public virtual bool HasLeftChild
        {
            get { return this.LeftChild != null; }
        }

        public virtual bool HasRightChild
        {
            get { return this.RightChild != null; }
        }
    }
}