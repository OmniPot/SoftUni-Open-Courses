using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        this.heap = new List<T>(elements);
        for (int i = this.heap.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public int Count
    {
        get { return this.heap.Count; }
    }

    public T ExtractMax()
    {
        var largestElement = this.heap[0];
        this.heap[0] = this.heap[this.heap.Count - 1];
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        return largestElement;
    }

    public T PeekMax()
    {
        var max = this.heap[0];
        return max;
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int startIndex)
    {
        var leftChildIndex = 2 * startIndex + 1;
        var rightChildIndex = 2 * startIndex + 2;
        var largestElementIndex = startIndex;

        if (leftChildIndex < this.heap.Count &&
            this.heap[leftChildIndex].CompareTo(this.heap[largestElementIndex]) > 0)
        {
            largestElementIndex = leftChildIndex;
        }
        if (rightChildIndex < this.heap.Count &&
            this.heap[rightChildIndex].CompareTo(this.heap[largestElementIndex]) > 0)
        {
            largestElementIndex = rightChildIndex;
        }

        if (largestElementIndex != startIndex)
        {
            T oldLargestElement = this.heap[startIndex];
            this.heap[startIndex] = this.heap[largestElementIndex];
            this.heap[largestElementIndex] = oldLargestElement;
            this.HeapifyDown(largestElementIndex);
        }
    }

    private void HeapifyUp(int startIndex)
    {
        var parentIndex = (startIndex - 1) / 2;
        while (startIndex > 0 && this.heap[startIndex].CompareTo(this.heap[parentIndex]) > 0)
        {
            T oldParent = this.heap[startIndex];
            this.heap[startIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = oldParent;

            startIndex = parentIndex;
            parentIndex = (startIndex - 1) / 2;
        }
    }
}
