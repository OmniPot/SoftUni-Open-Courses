using System;
using System.Collections.Generic;
using System.Linq;

public class SumAndAverage
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of numbers separated by a single space.");

        try
        {
            string inputString = Console.ReadLine();
            if (inputString == string.Empty)
            {
                throw new ArgumentNullException("Line of numbers canno be empty string!");
            }

            string[] inputSequence = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> parsedNumbers = inputSequence.Select(s => int.Parse(s.Trim())).ToList();

            var averageOfParsed = parsedNumbers.Average();
            var sumOfParsed = parsedNumbers.Sum();

            Console.WriteLine("Sum = " + sumOfParsed);
            Console.WriteLine("Average = " + averageOfParsed);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
