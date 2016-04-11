using System;
using System.Collections.Generic;
using System.Linq;

public class CountOfOccurancies
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Insert a sequence of numbers separated by a single space.");

            string inputString = Console.ReadLine();
            string[] inputSequence = inputString.Split(' ');
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException();
            }

            List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str)).ToList();
            SortedDictionary<int, int> occurancies = new SortedDictionary<int, int>();

            foreach (int t in parsedNumbers)
            {
                if (occurancies.ContainsKey(t))
                {
                    occurancies[t]++;
                }
                else
                {
                    occurancies.Add(t, 1);
                }
            }

            foreach (var number in occurancies.Keys)
            {
                Console.WriteLine("{0} -> {1} times", number, occurancies[number]);
            }
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

