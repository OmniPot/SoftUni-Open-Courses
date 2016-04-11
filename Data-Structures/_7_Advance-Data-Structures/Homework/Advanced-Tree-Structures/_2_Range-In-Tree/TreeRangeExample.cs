namespace _2_Range_In_Tree
{
    using System;
    using System.Linq;

    public class TreeRangeExample
    {
        public static void Main()
        {
            var tree = new AvlTree<int>();
            var input = Console.ReadLine().Split(' ').Select(str => int.Parse(str.Trim())).ToList();
            var range = Console.ReadLine().Split(' ').Select(str => int.Parse(str.Trim())).ToArray();

            input.ForEach(tree.Add);
            var elementsInRange = tree.Range(range[0], range[1]);

            Console.WriteLine(string.Join(", ", elementsInRange));
        }
    }
}