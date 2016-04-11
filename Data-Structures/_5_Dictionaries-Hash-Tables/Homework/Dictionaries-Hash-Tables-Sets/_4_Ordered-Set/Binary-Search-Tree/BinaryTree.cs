namespace _4_Ordered_Set
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> : ICollection<T>
        where T : IComparable
    {
        private readonly Comparison<IComparable> comparer = CompareElements;

        public BinaryTree(TraversalOrder traversalOrder = 0)
        {
            this.TraversalOrder = traversalOrder;
            this.Root = null;
            this.Count = 0;
        }

        public TraversalOrder TraversalOrder { get; set; }

        public BinaryTreeNode<T> Root { get; set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            var node = new BinaryTreeNode<T>(value);
            this.Add(node);
        }

        public void Add(BinaryTreeNode<T> node)
        {
            if (this.Root == null)
            {
                this.Root = node;
                node.Tree = this;
                this.Count++;
            }
            else
            {
                if (node.Parent == null)
                {
                    node.Parent = this.Root;
                }

                var insertLeftSide = this.comparer(node.Value, node.Parent.Value) <= 0;

                if (insertLeftSide)
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node;
                        this.Count++;
                        node.Tree = this;
                    }
                    else
                    {
                        node.Parent = node.Parent.LeftChild;
                        this.Add(node);
                    }
                }
                else
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node;
                        this.Count++;
                        node.Tree = this;
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        this.Add(node);
                    }
                }
            }
        }

        public bool Remove(T value)
        {
            var removeNode = this.Find(value);

            return this.Remove(removeNode);
        }

        private bool Remove(BinaryTreeNode<T> removeNode)
        {
            if (removeNode == null || removeNode.Tree != this)
            {
                return false;
            }

            var wasHead = removeNode == this.Root;

            if (this.Count == 1)
            {
                this.Root = null;
                removeNode.Tree = null;

                this.Count--;
            }
            else if (removeNode.IsLeaf)
            {
                if (removeNode.IsLeftChild)
                {
                    removeNode.Parent.LeftChild = null;
                }
                else
                {
                    removeNode.Parent.RightChild = null;
                }

                removeNode.Tree = null;
                removeNode.Parent = null;

                this.Count--;
            }
            else if (removeNode.ChildCount == 1)
            {
                if (removeNode.HasLeftChild)
                {
                    removeNode.LeftChild.Parent = removeNode.Parent;

                    if (wasHead)
                    {
                        this.Root = removeNode.LeftChild;
                    }

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.LeftChild;
                    }

                    else
                    {
                        removeNode.Parent.RightChild = removeNode.LeftChild;
                    }
                }
                else
                {
                    removeNode.RightChild.Parent = removeNode.Parent;

                    if (wasHead)
                        this.Root = removeNode.RightChild;

                    if (removeNode.IsLeftChild)
                    {
                        removeNode.Parent.LeftChild = removeNode.RightChild;
                    }
                    else
                    {
                        removeNode.Parent.RightChild = removeNode.RightChild;
                    }
                }

                removeNode.Tree = null;
                removeNode.Parent = null;
                removeNode.LeftChild = null;
                removeNode.RightChild = null;

                this.Count--;
            }
            else
            {
                var successorNode = removeNode.LeftChild;
                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                removeNode.Value = successorNode.Value;

                this.Remove(successorNode);
            }


            return true;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public BinaryTreeNode<T> Find(T value)
        {
            var node = this.Root;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }

                var searchLeft = this.comparer(value, node.Value) < 0;

                if (searchLeft)
                {
                    node = node.LeftChild;
                }
                else
                {
                    node = node.RightChild;
                }
            }

            return null;
        }

        public void Clear()
        {
            var enumerator = this.GetPostOrderEnumerator();
            while (enumerator.MoveNext())
            {
                this.Remove(enumerator.Current);
            }

            enumerator.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            switch (this.TraversalOrder)
            {
                case TraversalOrder.InOrder:
                    return this.GetInOrderEnumerator();
                case TraversalOrder.PostOrder:
                    return this.GetPostOrderEnumerator();
                case TraversalOrder.PreOrder:
                    return this.GetPreOrderEnumerator();
                default:
                    return this.GetInOrderEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] array, int startIndex)
        {
            var enumerator = this.GetEnumerator();

            for (var i = startIndex; i < array.Length; i++)
            {
                if (!enumerator.MoveNext())
                {
                    break;
                }

                array[i] = enumerator.Current;
            }
        }

        // Height methods
        public int GetHeight()
        {
            return this.GetHeight(this.Root);
        }

        public int GetHeight(T value)
        {
            var valueNode = this.Find(value);
            if (value != null)
            {
                return this.GetHeight(valueNode);
            }

            return 0;
        }

        public int GetHeight(BinaryTreeNode<T> startNode)
        {
            if (startNode == null)
            {
                return 0;
            }

            return 1 + Math.Max(this.GetHeight(startNode.LeftChild), this.GetHeight(startNode.RightChild));
        }

        // Depth methods
        public int GetDepth(T value)
        {
            var node = this.Find(value);
            return this.GetDepth(node);
        }

        public int GetDepth(BinaryTreeNode<T> startNode)
        {
            var depth = 0;

            if (startNode == null)
            {
                return depth;
            }

            var parentNode = startNode.Parent;
            while (parentNode != null)
            {
                depth++;
                parentNode = parentNode.Parent;
            }

            return depth;
        }

        public void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        public static int CompareElements(IComparable x, IComparable y)
        {
            return x.CompareTo(y);
        }

        private IEnumerator<T> GetInOrderEnumerator()
        {
            return new BinaryTreeInOrderEnumerator(this);
        }

        private IEnumerator<T> GetPostOrderEnumerator()
        {
            return new BinaryTreePostOrderEnumerator(this);
        }

        private IEnumerator<T> GetPreOrderEnumerator()
        {
            return new BinaryTreePreOrderEnumerator(this);
        }

        // Enumerators
        private class BinaryTreeInOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private readonly Queue<BinaryTreeNode<T>> traverseQueue;
            private BinaryTree<T> tree;

            public BinaryTreeInOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                this.traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.visitNode(this.tree.Root);
            }

            public T Current
            {
                get { return this.current.Value; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public void Dispose()
            {
                this.current = null;
                this.tree = null;
            }

            public void Reset()
            {
                this.current = null;
            }

            public bool MoveNext()
            {
                if (this.traverseQueue.Count > 0)
                {
                    this.current = this.traverseQueue.Dequeue();
                }
                else
                {
                    this.current = null;
                }

                return this.current != null;
            }

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }

                this.visitNode(node.LeftChild);
                this.traverseQueue.Enqueue(node);
                this.visitNode(node.RightChild);
            }
        }

        private class BinaryTreePostOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private readonly Queue<BinaryTreeNode<T>> traverseQueue;
            private BinaryTree<T> tree;

            public BinaryTreePostOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;
                this.traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.visitNode(this.tree.Root);
            }

            public T Current
            {
                get { return this.current.Value; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public void Dispose()
            {
                this.current = null;
                this.tree = null;
            }

            public void Reset()
            {
                this.current = null;
            }

            public bool MoveNext()
            {
                if (this.traverseQueue.Count > 0)
                {
                    this.current = this.traverseQueue.Dequeue();
                }
                else
                {
                    this.current = null;
                }

                return this.current != null;
            }

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }

                this.visitNode(node.LeftChild);
                this.visitNode(node.RightChild);
                this.traverseQueue.Enqueue(node);
            }
        }

        private class BinaryTreePreOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private readonly Queue<BinaryTreeNode<T>> traverseQueue;
            private BinaryTree<T> tree;

            public BinaryTreePreOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                this.traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.visitNode(this.tree.Root);
            }

            public T Current
            {
                get { return this.current.Value; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public void Dispose()
            {
                this.current = null;
                this.tree = null;
            }

            public void Reset()
            {
                this.current = null;
            }

            public bool MoveNext()
            {
                if (this.traverseQueue.Count > 0)
                {
                    this.current = this.traverseQueue.Dequeue();
                }
                else
                {
                    this.current = null;
                }

                return this.current != null;
            }

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }

                this.traverseQueue.Enqueue(node);
                this.visitNode(node.LeftChild);
                this.visitNode(node.RightChild);
            }
        }
    }
}