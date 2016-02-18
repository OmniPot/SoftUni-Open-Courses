using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private const char VisitedCell = 's';

    private static int width;
    private static int height;
    private static char[,] labyrinth;

    public static void Main()
    {
        ReadLabyrinth();
        var shortestPathToExit = FindShortestPathToExit();
        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPathToExit);
        }
    }

    private static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);
        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();
            //Console.WriteLine("Visited Cell: ({0}, {1})", currentCell.X, currentCell.Y);
            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", +1, 0);
            TryDirection(queue, currentCell, "D", 0, +1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }

        return null;
    }

    private static Point FindStartPosition()
    {
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (labyrinth[y, x] == VisitedCell)
                {
                    return new Point { X = x, Y = y };
                }
            }
        }

        return null;
    }

    private static bool IsExit(Point currentCell)
    {
        var isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        var isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;
        return isOnBorderX || isOnBorderY;
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        var newX = currentCell.X + deltaX;
        var newY = currentCell.Y + deltaY;
        if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newY, newX] == '-')
        {
            labyrinth[newY, newX] = VisitedCell;
            var nextCell = new Point
            {
                X = newX,
                Y = newY,
                Direction = direction,
                PreviousPoint = currentCell
            };

            queue.Enqueue(nextCell);
        }
    }

    private static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }

        return string.Join("", path.ToString().Reverse());
    }

    private static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());

        labyrinth = new char[height, width];
        for (int x = 0; x < height; x++)
        {
            var line = Console.ReadLine();
            for (int y = 0; y < line.Length; y++)
            {
                labyrinth[x, y] = line[y];
            }
        }
    }
}