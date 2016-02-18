using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSequence
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        string inputString = Console.ReadLine();
        string[] inputSequence = inputString.Split(' ');

        List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str)).ToList();

        Console.WriteLine(String.Join(" ", FindLongestSequence(parsedNumbers)));
    }

    public static List<int> FindLongestSequence(List<int> parsedNumbers)
    {
        List<List<int>> foundSequences = new List<List<int>>();
        for (int start = 0; start < parsedNumbers.Count; start++)
        {
            List<int> sequence = new List<int>() { parsedNumbers[start] };
            for (int subSequenceStart = start + 1; subSequenceStart < parsedNumbers.Count; subSequenceStart++)
            {
                if (parsedNumbers[start] != parsedNumbers[subSequenceStart])
                {
                    break;
                }

                sequence.Add(parsedNumbers[subSequenceStart]);
            }

            foundSequences.Add(sequence);
        }

        return foundSequences.OrderByDescending(s => s.Count).ToList()[0];
    }
}
