using System;
using System.Linq;

namespace _02._Array_Modifier
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "swap")
                {
                    int firstIndex = int.Parse(cmdArgs[1]);
                    int secondIndex = int.Parse(cmdArgs[2]);

                    int firstIndexNum = numbers[firstIndex];
                    int secondIndexNum = numbers[secondIndex];

                    numbers[firstIndex] = secondIndexNum;
                    numbers[secondIndex] = firstIndexNum;
                }
                else if (action == "multiply")
                {
                    int firstIndex = int.Parse(cmdArgs[1]);
                    int secondIndex = int.Parse(cmdArgs[2]);

                    numbers[firstIndex] *= numbers[secondIndex];
                }
                else if (action == "decrease")
                {
                    numbers = numbers.Select(x => x -= 1).ToArray();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}