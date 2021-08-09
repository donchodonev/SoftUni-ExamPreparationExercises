using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Travel")
            {
                if (command == "Add Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);

                    if (startIndex >= 0 && startIndex < stops.Length)
                    {
                        string stop = cmdArgs[2];
                        stops = stops.Insert(startIndex, stop);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (startIndex >= 0 && startIndex < stops.Length)
                    {
                        if (endIndex >= 0 && endIndex < stops.Length)
                        {
                            stops = stops.Remove(startIndex, Math.Max(startIndex, endIndex + 1) - Math.Min(startIndex, endIndex + 1));
                        }
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(stops);

                cmdArgs = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
