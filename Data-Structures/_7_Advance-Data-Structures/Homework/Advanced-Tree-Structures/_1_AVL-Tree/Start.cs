namespace _1_AVL_Tree
{
    using System;
    using System.Collections.Generic;

    public class Start
    {
        public static void Main()
        {
            var tree = new AvlTree<int>();
            var elements = new List<int> { 1, 5, 3, 20, 6, 13, 40, 70, 100, 200, -50 };

            elements.ForEach(tree.Add);

            Console.Write("AVL Tree elements: ");
            tree.ForeachDfs((depth, value) => { Console.Write("{0} ", value); });
            Console.WriteLine();
        }
    }
}