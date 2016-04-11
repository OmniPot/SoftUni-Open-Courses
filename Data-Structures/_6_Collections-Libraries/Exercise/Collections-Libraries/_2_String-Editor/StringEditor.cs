namespace _2_String_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StringEditor
    {
        private static BigList<char> text = new BigList<char>();
        private static List<string> commands = new List<string> { "APPEND", "INSERT", "DELETE", "REPLACE", "PRINT", "END" };

        public static void Main()
        {
            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                try
                {
                    ProcessInput(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static void ProcessInput(string input)
        {
            string[] lineElements = input.Split(new[] { ' ' }, 2).Select(e => e.Trim()).ToArray();
            string command = lineElements[0];
            string commandParams = lineElements.Length > 1 ? lineElements[1] : null;

            if (!commands.Contains(command.ToUpper()))
            {
                throw new ArgumentException(string.Format("Invalid command {0}", command));
            }

            switch (command.ToUpper())
            {
                case "APPEND":
                    Append(commandParams);
                    break;
                case "INSERT":
                    Insert(commandParams);
                    break;
                case "DELETE":
                    Delete(commandParams);
                    break;
                case "REPLACE":
                    Replace(commandParams);
                    break;
                case "PRINT":
                    Print();
                    break;
            }
        }

        private static void Append(string textToAppend)
        {
            text.AddRange(textToAppend.ToCharArray());
            Console.WriteLine("OK");
        }

        private static void Insert(string commandParams)
        {
            string[] cmdParams = commandParams.Split(new[] { ' ' }, 2);
            int index = int.Parse(cmdParams[0]);

            if (index < 0 || index > text.Count - 1)
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                text.InsertRange(index, cmdParams[1].ToCharArray());
                Console.WriteLine("OK");
            }
        }

        private static void Delete(string commandParams)
        {
            string[] cmdParams = commandParams.Split(new[] { ' ' }, 2);
            int index = int.Parse(cmdParams[0]);
            int count = int.Parse(cmdParams[1]);

            if (index < 0 || index > text.Count - 1 || index + count > text.Count)
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                text.RemoveRange(index, count);
                Console.WriteLine("OK");
            }
        }

        private static void Replace(string commandParams)
        {
            string[] cmdParams = commandParams.Split(new[] { ' ' }, 3);
            int index = int.Parse(cmdParams[0]);
            int count = int.Parse(cmdParams[1]);
            string replacement = cmdParams[2];

            if (index < 0 || index > text.Count - 1 || index + count > text.Count)
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                text.RemoveRange(index, count);
                text.InsertRange(index, replacement.ToCharArray());
                Console.WriteLine("OK");
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join("", text));
        }
    }
}