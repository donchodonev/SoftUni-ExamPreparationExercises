using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int wonBattles = 0;

            while (command != "End of battle")
            {
                int leftEnergy = energy - int.Parse(command);

                if (leftEnergy < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    return;
                }
                else
                {
                    energy -= int.Parse(command);
                    wonBattles++;
                }

                if (wonBattles % 3 == 0)
                {
                    energy += wonBattles;
                }

                command = Console.ReadLine();
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
            }
        }
    }
}