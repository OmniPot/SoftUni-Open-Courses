namespace _1_Play_With_Trees
{
    using System.Collections.Generic;
    using System.Linq;

    public class RecursiveTree<T>
    {
        public static Dictionary<int, RecursiveTree<int>> nodeByValue =
            new Dictionary<int, RecursiveTree<int>>();

        public RecursiveTree(T value, params RecursiveTree<T>[] children)
        {
            this.Value = value;
            this.Children = children.ToList();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public T Value { get; set; }

        public RecursiveTree<T> Parent { get; set; }

        public IList<RecursiveTree<T>> Children { get; private set; }

        public static RecursiveTree<int> GetTreeNodesByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new RecursiveTree<int>(value);
            }

            return nodeByValue[value];
        }

        public static RecursiveTree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public static IEnumerable<RecursiveTree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(node => node.Children.Count > 0 &&
                               node.Parent != null).ToList();
            return middleNodes;
        }

        public static IEnumerable<RecursiveTree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(node => node.Children.Count == 0).ToList();
            return leafNodes;
        }
    }
}
