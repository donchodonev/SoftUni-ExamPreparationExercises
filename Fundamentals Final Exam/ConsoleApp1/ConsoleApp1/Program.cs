using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Animal
    {
        public Animal(string name, int neededFood)
        {
            Name = name;
            NeededFood = neededFood;
        }
        public string Name { get; set; }
        public int NeededFood { get; set; }

        public bool IsFed
        {
            get
            {
                if (NeededFood <= 0)
                {
                    return true;
                }

                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} -> {NeededFood}g";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Animal>> zoo = new Dictionary<string, List<Animal>>();

            string[] cmdArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "EndDay")
            {
                if (command == "Add")
                {
                    string[] addArgs = cmdArgs[1]
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);

                    string name = addArgs[0];
                    int food = int.Parse(addArgs[1]);
                    string area = addArgs[2];

                    if (zoo.ContainsKey(area))
                    {
                        if (zoo[area].Any(x => x.Name == name))
                        {
                            zoo[area].First(x => x.Name == name).NeededFood += food;
                        }
                        else
                        {
                            zoo[area].Add(new Animal(name, food));
                        }
                    }
                    else
                    {
                        zoo.Add(area, new List<Animal>()
                        {
                            new Animal(name,food)
                        });
                    }
                }
                else
                {
                    string[] feedArgs = cmdArgs[1]
                        .Split('-', StringSplitOptions.RemoveEmptyEntries);


                    string name = feedArgs[0];
                    int food = int.Parse(feedArgs[1]);

                    foreach (var animals in zoo.Values)
                    {
                        if (animals.Any(x => x.Name == name))
                        {
                            animals.First(x => x.Name == name).NeededFood -= food;

                            if (animals.First(x => x.Name == name).IsFed)
                            {
                                animals.Remove(animals.First(x => x.Name == name));
                                Console.WriteLine($"{name} was successfully fed");
                            }
                        }
                    }
                }

                cmdArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            List<Animal> allCurrentAnimals = new List<Animal>();

            foreach (var kvp in zoo.Values)
            {
                foreach (var animal in kvp)
                {
                    allCurrentAnimals.Add(animal);
                }
            }

            Console.WriteLine("Animals:");
            foreach (var animal in allCurrentAnimals
                .OrderByDescending(x => x.NeededFood)
                .ThenBy(x => x.Name))
            {
                Console.WriteLine($" {animal}");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var keyValuePair in zoo
                .Where(x => x.Value.Count(x => !x.IsFed) > 0)
                .OrderByDescending(x => x.Value.Count(x => !x.IsFed))
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($" {keyValuePair.Key}: {zoo[keyValuePair.Key].Count(x => !x.IsFed)}");
            }
        }
    }
}
