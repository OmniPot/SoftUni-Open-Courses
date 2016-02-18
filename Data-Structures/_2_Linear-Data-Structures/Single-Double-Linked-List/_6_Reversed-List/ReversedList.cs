using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ReversedList<T> : IEnumerable<T>
{
    public ReversedList(int defaultLength)
    {
        this.Content = new T[defaultLength];
        this.Count = 0;
    }

    public int Capacity
    {
        get
        {
            return this.Content.Length;
        }
    }

    public int Count { get; private set; }

    private T[] Content { get; set; }

    public T this[int index]
    {
        get { return this.Content[this.Count - 1 - index]; }
    }

    public void Add(T item)
    {
        if (this.Capacity == this.Count)
        {
            var newContent = new T[this.Capacity * 2];
            Array.Copy(this.Content, newContent, this.Capacity);
            this.Content = newContent;
        }

        this.Content[this.Count] = item;
        this.Count++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException("Unavailable index to remove.");
        }

        var removedItem = this.Content[this.Count - 1 - index];
        var newContent = new T[this.Capacity - 1];
        Array.Copy(this.Content, newContent, index);
        Array.Copy(this.Content, index + 1, newContent, index, this.Count - index - 1);
        this.Content = newContent;
        this.Count--;

        return removedItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var index = this.Count - 1;
        T currentItem;

        while (index >= 0)
        {
            currentItem = this.Content[index--];
            yield return currentItem;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < this.Count; index++)
        {
            sb.Append(this.Content[this.Count - 1 - index] + " ");
        }

        return sb.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class TestClass
{
    public static void Main()
    {
        ReversedList<int> revList = new ReversedList<int>(2);

        Console.WriteLine("Count: " + revList.Count);
        Console.WriteLine("Capacity: " + revList.Capacity);

        revList.Add(1);
        revList.Add(2);
        revList.Add(3);

        Console.WriteLine("Count: " + revList.Count);
        Console.WriteLine("Capacity: " + revList.Capacity);

        revList.Add(4);
        revList.Add(5);
        revList.Add(6);
        revList.Add(7);
        revList.Add(8);
        revList.Add(9);

        Console.WriteLine("Count: " + revList.Count);
        Console.WriteLine("Capacity: " + revList.Capacity);

        Console.WriteLine();
        Console.WriteLine("To string: " + revList.ToString());
        Console.WriteLine();

        revList.Remove(3);
        Console.WriteLine("Item at index 3 removed. : " + revList.ToString());
        Console.WriteLine();
        
        revList.Add(4);
        Console.WriteLine("Item 4 added. : " + revList.ToString());
        Console.WriteLine();

        Console.Write("Enumerator (foreach): ");
        foreach (var item in revList)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}