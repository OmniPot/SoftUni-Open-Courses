namespace _2_Round_Dance
{
    using System;
    using System.Collections.Generic;

    public class RoundDance
    {
        private static Dictionary<int, List<int>> friendships = new Dictionary<int, List<int>>();

        public static void Main()
        {
            // Read graph
            int friendshipsCount = int.Parse(Console.ReadLine());
            int friendNumber = int.Parse(Console.ReadLine());

            friendships.Add(friendNumber, new List<int>());

            for (int i = 0; i < friendshipsCount; i++)
            {
                string[] couple = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int firstFriend = int.Parse(couple[0]);
                int secondFriend = int.Parse(couple[1]);

                if (!friendships.ContainsKey(firstFriend))
                {
                    friendships.Add(firstFriend, new List<int>());
                }

                if (!friendships.ContainsKey(secondFriend))
                {
                    friendships.Add(secondFriend, new List<int>());
                }

                friendships[firstFriend].Add(secondFriend);
                friendships[secondFriend].Add(firstFriend);
            }

            // Find the longest friendship
            HashSet<int> visitedFriends = new HashSet<int>();

            List<int> longestPath = LongestPathFromFriend(friendNumber, visitedFriends);
            Console.WriteLine("\nLongest path: {0}", string.Join(", ", longestPath));
            Console.WriteLine("Longest path Count: {0}", longestPath.Count);
        }

        private static List<int> LongestPathFromFriend(int friendNumber, HashSet<int> visitedFriends)
        {
            if (!visitedFriends.Contains(friendNumber))
            {
                visitedFriends.Add(friendNumber);

                List<int> longestPath = new List<int>();
                foreach (int number in friendships[friendNumber])
                {
                    List<int> childPath = LongestPathFromFriend(number, visitedFriends);
                    if (childPath.Count > longestPath.Count)
                    {
                        longestPath = childPath;
                    }
                }

                longestPath.Add(friendNumber);

                return longestPath;
            }

            return new List<int>();
        }
    }
}
