namespace Warm_Winter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarfs.Dequeue();
                    hats.Pop();
                    continue;
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(++hat);
                    continue;
                }

                while (hats.Count > 0)
                {
                    if (hats.Peek() < scarf)
                    {
                        hats.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(x => x).First()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
