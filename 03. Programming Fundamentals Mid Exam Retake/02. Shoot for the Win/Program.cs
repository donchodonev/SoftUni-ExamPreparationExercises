using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string index = Console.ReadLine();

            while (index != "End")
            {
                int indexNum = int.Parse(index);

                if (indexNum < 0 || indexNum > targets.Length - 1)
                {
                    index = Console.ReadLine();
                    continue;
                }

                int numberValue = targets[indexNum];

                if (targets[indexNum] != -1)
                {
                    targets[indexNum] = -1;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] > numberValue && targets[i] != -1)
                        {
                            targets[i] -= numberValue;
                        }
                        else if (targets[i] <= numberValue && targets[i] != -1)
                        {
                            targets[i] += numberValue;
                        }
                    }
                }

                index = Console.ReadLine();
            }

            int shotTargetsCount = targets
                .Where(x => x == -1)
                .Count();

            Console.WriteLine($"Shot targets: {shotTargetsCount} -> {string.Join(' ', targets)}");
        }
    }
}