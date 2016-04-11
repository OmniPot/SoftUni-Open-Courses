namespace _1_Find_the_Root
{
    using System;

    public class FindTheRoot
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            bool[] hasParent = new bool[n];
            for (int i = 0; i < m; i++)
            {
                string[] numPair = Console.ReadLine().Trim().Split(' ');
                int child = int.Parse(numPair[1]);
                hasParent[child] = true;
            }

            bool rootFound = false;
            string result = null;
            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    result = i.ToString();
                    rootFound = true;
                    break;
                }
            }


            if (!rootFound)
            {
                result = "No root!";
            }
            else if (n - m > 1)
            {
                result = "Multiple roots!";
            }

            Console.WriteLine(result);
        }
    }
}
