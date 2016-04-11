using System;
using System.Collections.Generic;

public class SquenceCalculator
{
    private const int NumerLimit = 50;

    public static void Main()
    {
        Console.Write("Insert a number to start the sequence: ");

        int startNumber = int.Parse(Console.ReadLine());

        Queue<int> numbersQueue = new Queue<int>();
        List<int> resultNumbers = new List<int>();

        numbersQueue.Enqueue(startNumber);
        while (numbersQueue.Count < NumerLimit * 2)
        {
            int currentNumber = numbersQueue.Dequeue();
            resultNumbers.Add(currentNumber);

            numbersQueue.Enqueue(currentNumber + 1);
            numbersQueue.Enqueue(2 * currentNumber + 1);
            numbersQueue.Enqueue(currentNumber + 2);
        }

        Console.WriteLine("Result: {0}", string.Join(", ", resultNumbers));
    }
}
