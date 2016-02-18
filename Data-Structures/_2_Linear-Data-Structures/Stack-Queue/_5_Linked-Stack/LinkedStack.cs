using System;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public LinkedStack()
    {
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop element from empty stack.");
        }

        var valueToReturn = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return valueToReturn;
    }

    public T[] ToArray()
    {
        if (this.Count == 0)
        {
            return new T[0];
        }

        var arrayToReturn = new T[this.Count];
        var currentNode = this.firstNode;
        var index = this.Count - 1;

        arrayToReturn[index] = currentNode.Value;
        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
            arrayToReturn[--index] = currentNode.Value;
        }        

        return arrayToReturn;
    }

    private class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> NextNode { get; private set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }
}

