using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            int cupidIndex = 0;

            while (command != "Love!")
            {
                int jumpLength = int.Parse(command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                cupidIndex += jumpLength;

                try
                {
                    if (houses[cupidIndex] > 0)
                    {
                        houses[cupidIndex] -= 2;

                        if (houses[cupidIndex] == 0)
                        {
                            Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                        }
                    }
                    else if (houses[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                    }
                }
                catch (Exception e)
                {
                    cupidIndex = 0;

                    if (houses[cupidIndex] > 0)
                    {
                        houses[cupidIndex] -= 2;

                        if (houses[cupidIndex] == 0)
                        {
                            Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                        }
                    }
                    else if (houses[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            if (houses.Where(x => x != 0).Count() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Where(x => x != 0).Count()} places.");
            }
        }
    }
}
