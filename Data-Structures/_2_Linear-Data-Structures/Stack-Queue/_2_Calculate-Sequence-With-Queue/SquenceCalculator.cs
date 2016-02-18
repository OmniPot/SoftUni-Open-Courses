using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SquenceCalculator
{
    public static void Main()
    {
        Console.WriteLine("Insert a number to start the sequence.");

        int startNumber = int.Parse(Console.ReadLine());

        Queue<int> numbersQueue = new Queue<int>();
        StringBuilder lineBuilder = new StringBuilder();

        numbersQueue.Enqueue(startNumber);
        while (numbersQueue.Count < 50)
        {
            int currentNumber = numbersQueue.Dequeue();
            lineBuilder.Append(currentNumber + " ");

            numbersQueue.Enqueue(currentNumber + 1);
            numbersQueue.Enqueue(2 * currentNumber + 1);
            numbersQueue.Enqueue(currentNumber + 2);
        }

        Console.WriteLine(lineBuilder.ToString());
    }
}
