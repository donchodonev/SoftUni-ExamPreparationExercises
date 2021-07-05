using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Numbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            double numAvg = numbers.Average();

            List<double> numsGreaterThanAvg = numbers
                .Where(x => x > numAvg)
                .ToList();

            if (numsGreaterThanAvg.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            int counter = 0;

            StringBuilder sb = new StringBuilder();

            foreach (var numb in numsGreaterThanAvg.OrderByDescending(x => x))
            {
                if (counter == 5)
                {
                    break;
                }

                sb.Append($"{numb} ");

                counter++;
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}