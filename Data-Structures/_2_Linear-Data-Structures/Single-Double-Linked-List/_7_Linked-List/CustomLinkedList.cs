using System;
using System.Collections;
using System.Collections.Generic;

public class CustomLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    public CustomListNode<T> Head { get; private set; }

    public void Add(T itemValue)
    {
        var newItem = new CustomListNode<T>(itemValue);
        if (this.Head == null)
        {
            this.Head = newItem;
        }
        else
        {
            var currentNode = this.Head;
            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.NextNode = newItem;
        }

        this.Count++;
    }

    public CustomListNode<T> Remove(int indexToRemove)
    {
        if (indexToRemove < 0 || indexToRemove > this.Count - 1)
        {
            throw new IndexOutOfRangeException("Invalid Index.");
        }

        if (indexToRemove == 0)
        {
            this.Head = this.Head.NextNode;
            return this.Head;
        }

        var currentNode = this.Head;
        var currentIndex = 1;

        while (indexToRemove != currentIndex)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        var removedNode = currentNode.NextNode;
        currentNode.NextNode = removedNode.NextNode;

        this.Count--;
        return removedNode;
    }

    public int FirstIndexOf(T item)
    {
        var currentNode = this.Head;
        var currentIndex = 0;

        while (currentNode.NextNode != null && !currentNode.Value.Equals(item))
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        return currentIndex != this.Count ? currentIndex : -1;
    }

    public int LastIndexOf(T item)
    {
        var currentNode = this.Head;
        var currentIndex = 0;
        var lastIndex = -1;

        while (currentNode.NextNode != null)
        {
            if (currentNode.Value.Equals(item))
            {
                lastIndex = currentIndex;
            }

            currentIndex++;
            currentNode = currentNode.NextNode;
        }

        if (currentNode.Value.Equals(item))
        {
            lastIndex = currentIndex;
        }

        return lastIndex;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while (currentNode.NextNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        yield return currentNode.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public class CustomListNode<T>
    {
        public CustomListNode(T value)
        {
            this.Value = value;
            this.NextNode = null;
        }

        public T Value { get; set; }

        public CustomListNode<T> NextNode { get; set; }
    }
}

public class TestClass
{
    public static void Main()
    {
        var list = new CustomLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(1);
        list.Add(1);
        list.Add(2);

        Console.Write("Foreach from Enumerator: ");
        Console.Write(string.Join(" ", list));

        Console.WriteLine();

        list.Remove(5);
        Console.Write("Element at index 5 removed: ");
        Console.Write(string.Join(" ", list));
        Console.WriteLine();

        list.Remove(0);
        Console.Write("Element at index 0 removed: ");
        Console.Write(string.Join(" ", list));
        Console.WriteLine();

        Console.WriteLine("First Index of 1: " + list.FirstIndexOf(1));
        Console.WriteLine("Last Index of 3: " + list.LastIndexOf(3));
    }
}