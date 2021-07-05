using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[0];

                if (command == "Collect")
                {
                    string item = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (!inventory.Contains(item))
                    {
                        inventory.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    string item = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    string items = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1];

                    string oldItem = items.Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
                    string newItem = items.Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (inventory.Contains(oldItem))
                    {
                        inventory.Insert(inventory.IndexOf(oldItem) + 1, newItem);
                    }
                }
                else if (command == "Renew")
                {
                    string item = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                        inventory.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",inventory));

        }
    }
}
