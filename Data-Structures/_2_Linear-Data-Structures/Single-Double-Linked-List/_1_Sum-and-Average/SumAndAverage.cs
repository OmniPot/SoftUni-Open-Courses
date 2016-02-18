using System;
using System.Collections.Generic;
using System.Linq;

public class SumAndAverage
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        string inputString = Console.ReadLine();
        string[] inputSequence = inputString.Split(' ');

        List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str)).ToList();

        var averageOfParsed = parsedNumbers.Average();
        var sumOfParsed = parsedNumbers.Sum();

        Console.WriteLine("Sum = " + sumOfParsed);
        Console.WriteLine("Average = " + averageOfParsed);
    }
}
