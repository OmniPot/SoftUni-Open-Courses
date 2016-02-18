using System;

public class LinkedQueue<T>
{
    private QueueNode<T> HeadNode;

    private QueueNode<T> TailNode;

    public LinkedQueue()
    {
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        var newNode = new QueueNode<T>(element);
        if (this.Count == 0)
        {
            this.HeadNode = newNode;
        }
        else if (Count == 1)
        {
            this.TailNode = newNode;
            this.TailNode.PrevNode = this.HeadNode;
            this.HeadNode.NextNode = this.TailNode;
        }
        else
        {
            newNode.PrevNode = this.TailNode;
            this.TailNode.NextNode = newNode;
            this.TailNode = newNode;
        }

        var currentNode = this.HeadNode;

        this.Count++;
    }

    public T Dequeue()
    {
        T toReturn = default(T);
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from empty queue.");
        }

        toReturn = HeadNode.Value;
        if (Count == 1)
        {
            this.HeadNode = null;
        }
        else
        {
            this.HeadNode = this.HeadNode.NextNode;
        }

        this.Count--;
        return toReturn;
    }

    public T[] ToArray()
    {
        if (this.Count == 0)
        {
            return new T[0];
        }

        var arrayToReturn = new T[this.Count];
        var currentNode = this.HeadNode;
        var index = 0;

        arrayToReturn[index] = currentNode.Value;
        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
            arrayToReturn[++index] = currentNode.Value;
        }

        Console.WriteLine(string.Join(", ", arrayToReturn));
        
        return arrayToReturn;
    }
    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }

    }
}
