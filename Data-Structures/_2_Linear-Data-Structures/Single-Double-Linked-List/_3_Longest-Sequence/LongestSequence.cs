using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSequence
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        try
        {
            string inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException();
            }

            string[] inputSequence = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str.Trim())).ToList();

            Console.WriteLine(String.Join(" ", FindLongestSequence(parsedNumbers)));
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

    }

    public static List<int> FindLongestSequence(List<int> parsedNumbers)
    {
        List<List<int>> foundSequences = new List<List<int>>();
        for (int start = 0; start < parsedNumbers.Count; start++)
        {
            List<int> sequence = new List<int> { parsedNumbers[start] };
            for (int subSeqIndex = start + 1; subSeqIndex < parsedNumbers.Count; subSeqIndex++)
            {
                if (parsedNumbers[start] != parsedNumbers[subSeqIndex])
                {
                    break;
                }

                sequence.Add(parsedNumbers[subSeqIndex]);
            }

            foundSequences.Add(sequence);
        }

        return foundSequences.OrderByDescending(s => s.Count).ToList()[0];
    }
}
