using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveOddOccurancies
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        string inputString = Console.ReadLine();
        string[] inputSequence = inputString.Split(' ');

        List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str)).ToList();
        Dictionary<int, int> occurancies = new Dictionary<int, int>();

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

        var result = parsedNumbers.Where(number => occurancies[number] % 2 == 0);
        Console.WriteLine(string.Join(" ", result));
    }
}

