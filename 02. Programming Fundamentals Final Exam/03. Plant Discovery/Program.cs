using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<double, List<double>>> plants = new Dictionary<string, Dictionary<double, List<double>>>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                double rating = double.Parse(cmdArgs[1]);

                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, new Dictionary<double, List<double>> { { rating, new List<double>()}});
                }
                else
                {
                    plants.Remove(name);
                    plants.Add(name, new Dictionary<double, List<double>> { { rating, new List<double>()}});

                }
            }

            string[] commandArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while (commandArgs[0] != "Exhibition")
            {

                if (commandArgs[0] == "Rate")
                {
                    string[] ratingsArr = commandArgs[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string plantName = ratingsArr[0];
                    double rating = double.Parse(ratingsArr[1]);

                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Values.Single().Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commandArgs[0] == "Update")
                {
                    string[] ratingsArr = commandArgs[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string plantName = ratingsArr[0];
                    double rarity = double.Parse(ratingsArr[1]);

                    if (plants.ContainsKey(plantName))
                    {
                        List<double> backupRatings = plants[plantName]
                            .Values
                            .Single();

                        plants.Remove(plantName);
                        plants.Add(plantName,new Dictionary<double, List<double>>{{rarity,backupRatings}});
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commandArgs[0] == "Reset")
                {
                    string plantName = commandArgs[1];

                    if (plants.ContainsKey(commandArgs[1]))
                    {
                        plants[plantName]
                            .Values
                            .Single()
                            .Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                commandArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");
            
            foreach (var plant in plants
                .OrderByDescending(x => x
                    .Value
                    .Keys
                    .First())
                .ThenByDescending(x => x
                    .Value
                    .Values
                    .Select(x => x.Average())
                ))
            {
                double rating = 0;

                double innerKey = plants[plant.Key].Select(x => x.Key).Single();

                try
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Keys.Single()}; Rating: {plants[plant.Key][innerKey].Average():F2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Keys.Single()}; Rating: 0.00");
                }
            }
        }
    }
}
