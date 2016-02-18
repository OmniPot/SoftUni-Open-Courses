namespace _1_Play_With_Trees
{
    using System;
    using System.Linq;

    public class PlayWithTrees
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                RecursiveTree<int> parentNode = RecursiveTree<int>.GetTreeNodesByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                RecursiveTree<int> childNode = RecursiveTree<int>.GetTreeNodesByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var rootNode = RecursiveTree<int>.FindRootNode();
            Console.WriteLine("Root node: " + rootNode.Value);

            var middleNodes = RecursiveTree<int>.FindMiddleNodes();
            Console.WriteLine("Middle nodes: " + String.Join(", ", middleNodes.Select(n => n.Value)));
            
            var leafNodes = RecursiveTree<int>.FindLeafNodes();
            Console.WriteLine("Leaf nodes: " + String.Join(", ", leafNodes.Select(n => n.Value)));
        }
    }
}
