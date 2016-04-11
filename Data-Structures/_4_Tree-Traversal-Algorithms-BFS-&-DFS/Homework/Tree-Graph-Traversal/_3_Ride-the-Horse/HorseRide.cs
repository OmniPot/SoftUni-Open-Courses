namespace _3_Ride_the_Horse
{
    using System;
    using System.Collections.Generic;

    public class HorseRide
    {
        private static int[,] board;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startColumn = int.Parse(Console.ReadLine());

            //int rows = 6;
            //int columns = 7;
            //int startRow = 3;
            //int startColumn = 4;

            board = new int[rows, columns];
            Bfs(new[] { startRow, startColumn, 1 });
        }

        private static void Bfs(int[] startCoords)
        {
            Queue<int[]> neighbours = new Queue<int[]>();
            neighbours.Enqueue(startCoords);

            while (neighbours.Count > 0)
            {
                int[] neighbour = neighbours.Dequeue();
                int nextValue = neighbour[2] + 1;

                board[neighbour[0], neighbour[1]] = neighbour[2];

                List<int[]> positions = new List<int[]>
                {
                    new[] { neighbour[0] - 2, neighbour[1] + 1, nextValue },
                    new[] { neighbour[0] - 1, neighbour[1] + 2, nextValue },
                    new[] { neighbour[0] + 1, neighbour[1] + 2, nextValue },
                    new[] { neighbour[0] + 2, neighbour[1] + 1, nextValue },
                    new[] { neighbour[0] + 2, neighbour[1] - 1, nextValue },
                    new[] { neighbour[0] + 1, neighbour[1] - 2, nextValue },
                    new[] { neighbour[0] - 1, neighbour[1] - 2, nextValue },
                    new[] { neighbour[0] - 2, neighbour[1] - 1, nextValue }
                };

                foreach (int[] position in positions)
                {
                    if (IsInBoard(position) && board[position[0], position[1]] == 0)
                    {
                        neighbours.Enqueue(position);
                    }
                }
            }

            PrintBoard();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("Result");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine(board[i, board.GetLength(1) / 2]);
            }
        }

        private static void PrintBoard()
        {
            Console.WriteLine("Final board");
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool IsInBoard(int[] coords, int up = 0, int right = 0, int down = 0, int left = 0)
        {
            bool inBoard = coords[1] - left >= 0 && coords[1] + right <= board.GetLength(1) - 1 &&
                coords[0] - up >= 0 && coords[0] + down <= board.GetLength(0) - 1;

            return inBoard;
        }
    }
}
