using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveOddOccurancies
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Insert a sequence of numbers separated by a single space.");

            string inputString = Console.ReadLine();
            string[] inputSequence = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException();
            }

            List<int> parsedNumbers = inputSequence.Select(str => int.Parse(str.Trim())).ToList();
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
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

