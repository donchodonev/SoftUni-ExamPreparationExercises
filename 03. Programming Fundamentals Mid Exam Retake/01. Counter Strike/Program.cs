using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int wonBattles = 0;

            while (command != "End of battle")
            {
                int leftEnergy = energy - int.Parse(command);

                if (leftEnergy == 0)
                {
                    energy -= int.Parse(command);
                    wonBattles++;
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    return;
                }
                else if (leftEnergy < 0)
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

            Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
        }
    }
}