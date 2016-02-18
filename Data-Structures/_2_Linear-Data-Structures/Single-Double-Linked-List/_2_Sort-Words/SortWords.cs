using System;
using System.Collections.Generic;
using System.Linq;

public class SortWords
{
    public static void Main()
    {
        Console.WriteLine("Insert a sequence of strings separated by a single space.");

        string inputString = Console.ReadLine();

        List<string> parsedWords = inputString.Split(' ').ToList();

        parsedWords.Sort();

        Console.Write("Sorted alphabetically:");
        parsedWords.ForEach(w => Console.WriteLine(w + " "));
    }
}

