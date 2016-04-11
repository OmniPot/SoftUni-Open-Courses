using System;

public class CustomDictionaryExample
{
    public static void Main()
    {
        // Count symbols
        CustomDictionary<char, int> symbols = new CustomDictionary<char, int>();

        char[] inputSymbols = Console.ReadLine().ToCharArray();
        Array.Sort(inputSymbols);

        foreach (char symbol in inputSymbols)
        {
            if (symbols.ContainsKey(symbol))
            {
                symbols[symbol]++;
            }
            else
            {
                symbols.Add(symbol, 1);
            }
        }

        foreach (KeyValue<char, int> pair in symbols)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value + " " + (pair.Value == 1 ? "time" : "times"));
        }
    }
}