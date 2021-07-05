using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentCount = int.Parse(Console.ReadLine());
            double lecturesCount = int.Parse(Console.ReadLine());
            double additionalBonus = int.Parse(Console.ReadLine());

            if (studentCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            List<int> studentsAttendance = new List<int>();

            for (int i = 0; i < studentCount; i++)
            {
                studentsAttendance.Add(int.Parse(Console.ReadLine()));
            }

            double mostAttendingStudent = studentsAttendance.OrderByDescending(x => x).First();

            double currentBonus = Math.Ceiling(mostAttendingStudent / lecturesCount * (5 + additionalBonus));

            Console.WriteLine($"Max Bonus: {currentBonus}.");
            Console.WriteLine($"The student has attended {studentsAttendance.Max()} lectures.");

        }
    }
}
