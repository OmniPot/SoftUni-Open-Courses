namespace _3_Phonebook
{
    using System;

    public class Phonebook
    {
        static void Main()
        {
            CustomDictionary<string, string> phonebook = new CustomDictionary<string, string>();

            string input = Console.ReadLine();
            ReadEntries(input, phonebook);

            input = Console.ReadLine();
            SearchEntries(input, phonebook);
        }

        private static void SearchEntries(string input, CustomDictionary<string, string> phonebook)
        {
            while (input != "exit")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Empty entry!");
                }
                else
                {
                    string name = input;
                    if (!phonebook.ContainsKey(name))
                    {
                        Console.WriteLine("Contact {0} does not exist.", name);
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void ReadEntries(string input, CustomDictionary<string, string> phonebook)
        {
            while (input != "search")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Empty entry!");
                }
                else
                {
                    string[] entry = input.Split('-');
                    string name = entry[0];
                    string number = entry[1];

                    if (phonebook.ContainsKey(name))
                    {
                        phonebook[name] = number;
                    }
                    else
                    {
                        phonebook.Add(name, number);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
