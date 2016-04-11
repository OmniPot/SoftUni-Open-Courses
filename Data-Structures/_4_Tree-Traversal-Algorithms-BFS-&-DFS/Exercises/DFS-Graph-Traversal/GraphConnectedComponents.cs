using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph =
    {
        new List<int> {3, 6},
        new List<int> {3, 4, 5, 6},
        new List<int> {8},
        new List<int> {0, 1, 5},
        new List<int> {1, 6},
        new List<int> {1, 3},
        new List<int> {0, 1, 4},
        new List<int>(),
        new List<int> {2}
    };

    private static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        var n = int.Parse(Console.ReadLine());
        List<int>[] newGraph = new List<int>[n];
        for (var i = 0; i < newGraph.Length; i++)
        {
            newGraph[i] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        return newGraph;
    }

    private static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var childNode in graph[node])
            {
                DFS(childNode);
            }

            Console.Write(" " + node);
        }
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];
        for (var i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
    }
}