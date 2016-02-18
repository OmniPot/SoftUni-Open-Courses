using System;
using System.Collections.Generic;
using System.Linq;

public class CountOfOccurancies
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        string inputString = Console.ReadLine();
        string[] inputSequence = inputString.Split(' ');

        List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str)).ToList();
        SortedDictionary<int, int> occurancies = new SortedDictionary<int, int>();

        for (int numIndex = 0; numIndex < parsedNumbers.Count; numIndex++)
        {
            if (occurancies.ContainsKey(parsedNumbers[numIndex]))
            {
                occurancies[parsedNumbers[numIndex]]++;
            }
            else
            {
                occurancies.Add(parsedNumbers[numIndex], 1);
            }
        }

        foreach (var number in occurancies.Keys)
        {
            Console.WriteLine("{0} -> {1} times", number, occurancies[number]);
        }
    }
}

