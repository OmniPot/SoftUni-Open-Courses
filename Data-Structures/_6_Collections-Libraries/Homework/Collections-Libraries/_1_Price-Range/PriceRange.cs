namespace _1_Price_Range
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PriceRange
    {
        public static void Main()
        {
            OrderedMultiDictionary<decimal, string> items = ReadItems();

            decimal[] fromTo = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            OrderedMultiDictionary<decimal, string>.View itemsInRange = SearchInRange(fromTo, items);

            Console.WriteLine();
            Console.WriteLine("OUTPUT");
            foreach (var product in itemsInRange)
            {
                Console.WriteLine("{0} - {1}", product.Key, string.Join(",", product.Value));
            }
        }

        private static OrderedMultiDictionary<decimal, string>.View SearchInRange(
            decimal[] fromTo,
            OrderedMultiDictionary<decimal, string> items)
        {
            if (fromTo[0] > fromTo[1])
            {
                throw new ArgumentException("Lower range boundry should be less than the upper one.");
            }

            return items.Range(fromTo[0], true, fromTo[1], true);
        }

        private static OrderedMultiDictionary<decimal, string> ReadItems()
        {
            int itemsCount = int.Parse(Console.ReadLine());
            OrderedMultiDictionary<decimal, string> items = new OrderedMultiDictionary<decimal, string>(true);

            for (int i = 0; i < itemsCount; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                string product = line[0];
                decimal price = decimal.Parse(line[1]);

                items.Add(price, product);
            }

            return items;
        }
    }
}