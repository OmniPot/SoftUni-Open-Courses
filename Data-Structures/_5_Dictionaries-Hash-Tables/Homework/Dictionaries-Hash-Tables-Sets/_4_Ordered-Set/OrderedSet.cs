namespace _4_Ordered_Set
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable
    {
        private BinaryTree<T> elements;

        public OrderedSet()
        {
            this.elements = new BinaryTree<T>();
        }

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Add(T element)
        {
            if (this.elements.Contains(element))
            {
                throw new ArgumentException("Duplicates are not allowed withing the set.");
            }

            this.elements.Add(element);
        }

        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public bool Remove(T element)
        {
            return this.elements.Remove(element);
        }

        public void CopyTo(T[] targetArray)
        {
            this.elements.CopyTo(targetArray);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}