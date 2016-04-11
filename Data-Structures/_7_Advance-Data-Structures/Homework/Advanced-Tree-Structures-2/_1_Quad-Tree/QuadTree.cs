namespace _1_Quad_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuadTree<T> where T : IBoundable
    {
        public const int DefaultMaxDepth = 5;
        public readonly int MaxDepth;

        private readonly Node<T> root;

        public QuadTree(int width, int height, int maxDepth = DefaultMaxDepth)
        {
            this.root = new Node<T>(0, 0, width, height);
            this.Bounds = this.root.Bounds;
            this.MaxDepth = maxDepth;
        }

        public int Count { get; private set; }

        public Rectangle Bounds { get; private set; }

        public bool Insert(T item)
        {
            if (!item.Bounds.IsInside(this.root.Bounds))
            {
                return false;
            }

            var depth = 1;
            var currentNode = this.root;
            while (currentNode.Children != null)
            {
                var quadrant = GetQuadrant(currentNode, item.Bounds);
                if (quadrant == -1)
                {
                    break;
                }

                depth++;
                currentNode = currentNode.Children[quadrant];
            }

            currentNode.Items.Add(item);
            this.Split(currentNode, depth);
            this.Count++;

            return true;
        }

        public List<T> Report(Rectangle bounds)
        {
            var collisionCandidates = new List<T>();

            GetCollisionCandidates(this.root, bounds, collisionCandidates);

            return collisionCandidates;
        }

        public void ForEachDfs(Action<List<T>, int, int> action)
        {
            this.ForEachDfs(this.root, action);
        }

        private static void GetCollisionCandidates(Node<T> node, Rectangle bounds, List<T> results)
        {
            var quadrant = GetQuadrant(node, bounds);
            if (quadrant == -1)
            {
                GetSubtreeContents(node, bounds, results);
            }
            else
            {
                if (node.Children != null)
                {
                    GetCollisionCandidates(node.Children[quadrant], bounds, results);
                }

                results.AddRange(node.Items);
            }
        }

        private static void GetSubtreeContents(Node<T> node, Rectangle bounds, List<T> results)
        {
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    if (child.Bounds.Intersects(bounds))
                    {
                        GetSubtreeContents(child, bounds, results);
                    }
                }
            }

            results.AddRange(node.Items);
        }

        private static int GetQuadrant(Node<T> node, Rectangle bounds)
        {
            var inTopQuadrant = node.Bounds.Y1 <= bounds.Y1 && bounds.Y2 <= node.Bounds.MidY;
            var inBottomQuadrant = node.Bounds.MidY <= bounds.Y1 && bounds.Y2 <= node.Bounds.Y2;
            var inLeftQuadrant = node.Bounds.X1 <= bounds.X1 && bounds.X2 <= node.Bounds.MidX;
            var inRightQuadrant = node.Bounds.MidX <= bounds.X1 && bounds.X2 <= node.Bounds.X2;

            if (inRightQuadrant)
            {
                if (inTopQuadrant)
                    return 0;
                if (inBottomQuadrant)
                    return 3;
            }
            else if (inLeftQuadrant)
            {
                if (inTopQuadrant)
                    return 1;
                if (inBottomQuadrant)
                    return 2;
            }

            return -1;
        }

        private void Split(Node<T> node, int nodeDepth)
        {
            if (!(node.ShouldSplit && nodeDepth < this.MaxDepth))
            {
                return;
            }

            var leftWidth = node.Bounds.Width/2;
            var rightWidth = node.Bounds.Width - leftWidth;
            var topHeight = node.Bounds.Height/2;
            var bottomHeight = node.Bounds.Height - topHeight;

            node.Children = new Node<T>[4];

            node.Children[0] = new Node<T>(node.Bounds.MidX, node.Bounds.Y1, rightWidth, topHeight);
            node.Children[1] = new Node<T>(node.Bounds.X1, node.Bounds.Y1, leftWidth, topHeight);
            node.Children[2] = new Node<T>(node.Bounds.X1, node.Bounds.MidY, leftWidth, bottomHeight);
            node.Children[3] = new Node<T>(node.Bounds.MidX, node.Bounds.MidY, rightWidth, bottomHeight);

            for (var i = 0; i < node.Items.Count; i++)
            {
                var item = node.Items[i];
                var quadrant = GetQuadrant(node, item.Bounds);
                if (quadrant != -1)
                {
                    node.Children[quadrant].Items.Add(item);
                    node.Items.Remove(item);
                    i--;
                }
            }

            foreach (var child in node.Children)
            {
                this.Split(child, nodeDepth + 1);
            }
        }

        private void ForEachDfs(Node<T> node, Action<List<T>, int, int> action, int depth = 1, int quadrant = 0)
        {
            if (node != null)
            {
                return;
            }

            if (node.Items.Any())
            {
                action(node.Items, depth, quadrant);
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    this.ForEachDfs(child, action, depth, quadrant);
                }
            }
        }
    }
}