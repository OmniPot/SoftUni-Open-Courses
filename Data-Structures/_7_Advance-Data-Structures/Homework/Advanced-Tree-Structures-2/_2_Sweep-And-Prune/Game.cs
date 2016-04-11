namespace _2_Sweep_And_Prune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private static int TickCount = 1;
        private static List<GameObject> objects;

        public static void Main()
        {
            objects = new List<GameObject>();

            string line = Console.ReadLine();
            while (line != "start")
            {
                string[] inputData = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(obj => obj.Trim())
                    .ToArray();

                if (inputData[0].Equals("add"))
                {
                    string objName = inputData[1];
                    int X1 = int.Parse(inputData[2]);
                    int Y1 = int.Parse(inputData[3]);
                    objects.Add(new GameObject(objName, X1, Y1));
                }

                line = Console.ReadLine();
            }

            objects.Sort((o1, o2) => o1.Bounds.X1.CompareTo(o2.Bounds.X1));

            while (true)
            {
                line = Console.ReadLine();

                string[] inputData = line
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(obj => obj.Trim())
                        .ToArray();
                string command = inputData[0].Trim();

                if (command.Equals("move"))
                {
                    string objName = inputData[1];
                    int newX1 = int.Parse(inputData[2]);
                    int newY1 = int.Parse(inputData[3]);

                    GameObject objToMove = objects.Find(obj => obj.Name.Equals(objName));
                    objToMove.Move(newX1, newY1);
                }

                if (command.Equals("move") || command.Equals("tick"))
                {
                    objects = GetSortedGameObjects(objects);
                    CheckCollisions();
                }

                TickCount++;
            }
        }

        private static void CheckCollisions()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject current = objects[i];
                for (int j = i + 1; j < objects.Count; j++)
                {
                    GameObject next = objects[j];
                    if (current.Bounds.Intersects(next.Bounds))
                    {
                        Console.WriteLine("({0}) {1} collides {2}", TickCount, current.Name, next.Name);
                    }
                }
            }
        }

        private static List<GameObject> GetSortedGameObjects(List<GameObject> objects)
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (objects[j - 1].Bounds.X1 > objects[j].Bounds.X1)
                    {
                        GameObject temp = objects[j - 1];
                        objects[j - 1] = objects[j];
                        objects[j] = temp;
                    }

                    j--;
                }
            }

            return objects;
        }
    }
}
