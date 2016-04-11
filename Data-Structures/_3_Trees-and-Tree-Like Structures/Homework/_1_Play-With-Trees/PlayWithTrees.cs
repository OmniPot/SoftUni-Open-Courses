namespace _1_Play_With_Trees
{
    using System;
    using System.Linq;
    using System.Text;

    public class PlayWithTrees
    {
        private static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            for (var i = 1; i < nodesCount; i++)
            {
                var edgeString = Console.ReadLine();
                var edgeArr = edgeString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var parentNode = Tree<int>.GetTreeNodesByValue(int.Parse(edgeArr[0]));
                var childNode = Tree<int>.GetTreeNodesByValue(int.Parse(edgeArr[1]));

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var pathSumStr = Console.ReadLine();
            var pathSum = int.Parse(pathSumStr);

            var subtreeStr = Console.ReadLine();
            var subtreeSum = int.Parse(subtreeStr);

            // 1 - Root Node
            var rootNode = Tree<int>.GetRootNode();
            Console.WriteLine("Root node: " + rootNode.Value);

            // 2 - Middle Nodes
            var middleNodes = Tree<int>.GetMiddleNodes();
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleNodes.Select(n => n.Value)));

            // 3 - Leaf Nodes
            var leafNodes = Tree<int>.GetLeafNodes();
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafNodes.Select(n => n.Value)));

            // 4 - Longest Path
            var path = Tree<int>.GetRootNode().LongestPath;
            Console.WriteLine("Longest path: {0} (length = {1})", string.Join(" -> ", path.Select(node => node.Value)),
                path.Count);

            // 5 - Paths with given sum
            Console.WriteLine("Paths of sum {0}:", pathSum);
            Tree<int>.GetPathsWithGivenSum(rootNode, pathSum, 0, new StringBuilder());
        }
    }
}