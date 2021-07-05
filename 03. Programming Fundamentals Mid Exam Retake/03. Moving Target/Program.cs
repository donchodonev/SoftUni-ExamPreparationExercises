using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    public class Program
    {
        public static bool IsIndexValid(int index, int listCount)
        {
            return index >= 0 && index < listCount;
        }

        public static bool IsRadiusValid(int index, int radius, int listCount)
        {
            return index - radius >= 0 && index + radius < listCount;
        }

        public static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);
                int value = int.Parse(cmdArgs[2]);

                if (action == "Shoot")
                {
                    if (IsIndexValid(index, targets.Count))
                    {
                        targets[index] -= value;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    if (IsIndexValid(index, targets.Count))
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (action == "Strike")
                {
                    if (IsIndexValid(index, targets.Count))
                    {
                        if (IsRadiusValid(index, value, targets.Count))
                        {
                            targets.RemoveRange(index - 1, value * 2 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}