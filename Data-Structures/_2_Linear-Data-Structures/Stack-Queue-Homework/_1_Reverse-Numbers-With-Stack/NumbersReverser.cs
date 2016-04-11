using System;
using System.Collections.Generic;
using System.Linq;

public class NumbersReverser
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        string inputString = Console.ReadLine();
        string[] inputSequence = inputString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> parsedNumbers = inputSequence.Select(int.Parse).ToList();
        Stack<int> numbersStack = new Stack<int>(parsedNumbers);

        Console.WriteLine("Reversed: " + string.Join(", ", numbersStack));
    }
}