using System;
using System.Linq;

public class ArrayBasedStack<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;

    public ArrayBasedStack(int capacity = InitialCapacity)
    {
        this.Count = 0;
        this.Capacity = capacity;
        this.elements = new T[InitialCapacity];
    }

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.elements.Length;
        }

        private set
        {
        }
    }

    public void Push(T element)
    {
        if (this.Count == this.Capacity)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop element from empty stack.");
        }

        this.Count--;
        return this.elements[this.Count];
    }

    public T[] ToArray()
    {
        if (this.Count == 0)
        {
            return new T[0];
        }

        var arrayToReturn = new T[this.Count];
        Array.Copy(this.elements, arrayToReturn, this.Count);
        Array.Reverse(arrayToReturn);
        return arrayToReturn;
    }

    private void Grow()
    {
        var biggerArray = new T[this.Capacity * 2];
        Array.Copy(this.elements, biggerArray, this.Count);
        this.elements = biggerArray;
    }
}