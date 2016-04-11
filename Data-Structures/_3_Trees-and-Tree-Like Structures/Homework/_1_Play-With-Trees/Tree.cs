namespace _1_Play_With_Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T>
    {
        private static readonly Dictionary<T, Tree<T>> nodeByValue = new Dictionary<T, Tree<T>>();

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; private set; }

        public List<Tree<T>> LongestPath
        {
            get
            {
                var longestPath = new List<Tree<T>>();
                foreach (var child in this.Children)
                {
                    var childPath = child.LongestPath;
                    if (childPath.Count > longestPath.Count)
                    {
                        longestPath = childPath;
                    }
                }

                longestPath.Add(this);
                longestPath.Reverse();

                return longestPath;
            }
        }

        public static Tree<T> GetTreeNodesByValue(T value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<T>(value);
            }

            return nodeByValue[value];
        }

        public static Tree<T> GetRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public static IEnumerable<Tree<T>> GetMiddleNodes()
        {
            var middleNodes = nodeByValue
                .Values
                .Where(node => node.Children.Count > 0 && node.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return middleNodes;
        }

        public static IEnumerable<Tree<T>> GetLeafNodes()
        {
            var leafNodes = nodeByValue
                .Values
                .Where(node => node.Children.Count == 0 && node.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return leafNodes;
        }

        public static void GetPathsWithGivenSum(Tree<int> node, int sum, int currentSum, StringBuilder buffer)
        {
            var newSum = currentSum + node.Value;
            var newBuffer = new StringBuilder();
            newBuffer.Append(buffer + " -> " + node.Value);

            if (newSum == sum)
            {
                Console.WriteLine(newBuffer.ToString().TrimStart(' ', '-', '>'));
            }

            foreach (var child in node.Children)
            {
                GetPathsWithGivenSum(child, sum, newSum, newBuffer);
            }
        }
    }
}