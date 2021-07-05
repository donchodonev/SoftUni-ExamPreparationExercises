using System;
using System.ComponentModel;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiencyPerHour = 0;

            for (int i = 0; i < 3; i++)
            {
                efficiencyPerHour += int.Parse(Console.ReadLine());
            }

            int peopleToBeAnswered = int.Parse(Console.ReadLine());

            int hoursNeeded = 0;


            while (peopleToBeAnswered > 0)
            {
                for (int i = 0; i < 3 && peopleToBeAnswered > 0; i++)
                {
                    peopleToBeAnswered -= efficiencyPerHour;
                    hoursNeeded++;

                    if (i == 2 && peopleToBeAnswered > 0)
                    {
                        hoursNeeded++;
                    }
                }
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
