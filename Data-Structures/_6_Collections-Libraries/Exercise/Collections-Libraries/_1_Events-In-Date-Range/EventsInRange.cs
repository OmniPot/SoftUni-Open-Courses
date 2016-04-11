namespace _1_Events_In_Date_Range
{
    using System;
    using Wintellect.PowerCollections;

    public class EventsInRange
    {
        public static void Main()
        {
            Console.WriteLine("INPUT");

            int rowsCount = int.Parse(Console.ReadLine());
            OrderedMultiDictionary<DateTime, string> events = new OrderedMultiDictionary<DateTime, string>(true);

            for (int i = 0; i < rowsCount; i++)
            {
                string[] input = Console.ReadLine().Split('|');

                string eventName = input[0].Trim();
                DateTime eventDate = DateTime.Parse(input[1].Trim());

                events.Add(eventDate, eventName);
            }

            int rangesCount = int.Parse(Console.ReadLine());

            Console.WriteLine("OUTPUT");

            for (int i = 0; i < rangesCount; i++)
            {
                string[] searchInterval = Console.ReadLine().Split('|');

                DateTime startDate = DateTime.Parse(searchInterval[0]);
                DateTime endDate = DateTime.Parse(searchInterval[1]);

                OrderedMultiDictionary<DateTime, string>.View eventsInRange =
                    events.Range(startDate, true, endDate, true);

                Console.WriteLine(eventsInRange.Values.Count);
                foreach (var ev in eventsInRange)
                {
                    foreach (var evValue in ev.Value)
                    {
                        Console.WriteLine("{0} | {1:dd-MMM-yyyy}", evValue, ev.Key);
                    }
                }
            }
        }
    }
}