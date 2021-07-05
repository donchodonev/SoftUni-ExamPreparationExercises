using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            string[] rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < rooms.Length; i++)
            {
                string item = rooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string value = rooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                if (item == "potion")
                {
                    if (health + int.Parse(value) > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else
                    {
                        health += int.Parse(value);
                        Console.WriteLine($"You healed for {int.Parse(value)} hp.");
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (item == "chest")
                {
                    bitcoins += int.Parse(value);
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    health -= int.Parse(value);

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {item}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {item}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }


            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
