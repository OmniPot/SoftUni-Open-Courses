namespace _4_Ordered_Set
{
    using System;
    using System.Linq;

    public class OrderedSetExample
    {
        public static void Main()
        {
            OrderedSet<int> orderedSet = new OrderedSet<int>();

            // Add()
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            Console.WriteLine("Initial set: {0}", string.Join(", ", orderedSet));

            try
            {
                // No duplicates allowed
                Console.Write("Try to add 9: ");
                orderedSet.Add(9);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Remove()
            orderedSet.Remove(12);
            Console.WriteLine("Removed 12: {0}", string.Join(", ", orderedSet));

            //Contains()
            Console.WriteLine("Containes 9: {0}", orderedSet.Contains(9));

            // CopyTo()
            int[] array = new int[orderedSet.Count];
            orderedSet.CopyTo(array);
            Console.WriteLine("Copied to array: {0}", string.Join(", ", array));

            // Count
            Console.WriteLine("Count: {0}", orderedSet.Count);
        }
    }
}