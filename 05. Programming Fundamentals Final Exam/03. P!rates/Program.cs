using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Town
    {
        public Town(int population, int gold, string name)
        {
            Population = population;
            Gold = gold;
            Name = name;
        }

        public string Name { get; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public bool IsWiped
        {
            get
            {
                if (Population <= 0 || Gold <= 0)
                {
                    return true;
                }

                return false;
            }
        }

        public void Plunder(int people, int gold)
        {
            Population -= people;
            Gold -= gold;

            Console.WriteLine($"{Name} plundered! {gold} gold stolen, {people} citizens killed.");
        }

        public void Prosper(int gold)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {Name} now has {Gold} gold.");
            }
        }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Town> towns = new Dictionary<string, Town>();

            string[] townArgs = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);

            while (townArgs[0] != "Sail")
            {
                string townName = townArgs[0];
                int population = int.Parse(townArgs[1]);
                int gold = int.Parse(townArgs[2]);

                if (towns.ContainsKey(townName))
                {
                    towns[townName].Gold += gold;
                    towns[townName].Population += population;
                }
                else
                {
                    towns.Add(townName, new Town(population, gold, townName));
                }

                townArgs = Console.ReadLine()
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] cmdArgs = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);


            while (cmdArgs[0] != "End")
            {
                string command = cmdArgs[0];
                string name = cmdArgs[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);

                    towns[name].Plunder(people,gold);

                    if (towns[name].IsWiped)
                    {
                        towns.Remove(name);
                        Console.WriteLine($"{name} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(cmdArgs[2]);

                    towns[name].Prosper(gold);
                }

                cmdArgs = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            if (towns.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns
                    .OrderByDescending(x => x.Value.Gold)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine(town.Value);
                }
            }
        }
    }
}
