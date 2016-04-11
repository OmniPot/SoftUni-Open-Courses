using System;
using System.Collections.Generic;
using System.Linq;

public class SortWords
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of strings separated by a single space.");

        try
        {
            string inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentNullException();
            }

            List<string> parsedWords = inputString.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            parsedWords.Sort();

            Console.Write("Sorted alphabetically:");
            parsedWords.ForEach(w => Console.WriteLine(w + " "));
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

