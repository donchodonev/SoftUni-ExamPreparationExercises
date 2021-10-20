namespace Masterchef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static readonly Dictionary<string, int> dishessFreshnessRequired = new Dictionary<string, int>()
        {
            {"Dipping sauce", 150},
            {"Green salad", 250},
            {"Chocolate cake", 300},
            {"Lobster", 400}
        };

        private static Dictionary<string, int> cookedDishes = new Dictionary<string, int>()
        {
            {"Dipping sauce", 0},
            {"Green salad", 0},
            {"Chocolate cake", 0},
            {"Lobster", 0}
        };

        public static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>();
            Stack<int> freshnessLevels = new Stack<int>();

            ProcessInput(ingredients, freshnessLevels);

            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                if (ingredients.Peek() != 0)
                {
                    int currentFreshnessValue = GetFreshness(ingredients.Peek(), freshnessLevels.Pop());

                    if (IsDishCooked(currentFreshnessValue))
                    {
                        ingredients.Dequeue();
                    }
                    else
                    {
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                    }
                }
                else
                {
                    ingredients.Dequeue();
                }
            }

            if (IsTaskSuccessful(cookedDishes))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            PrintCookedDishes(cookedDishes);
        }

        private static void ProcessInput(Queue<int> ingredients, Stack<int> freshnessLevels)
        {
            int[] inputIngredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputFreshnessLevel = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var ingredient in inputIngredients)
            {
                ingredients.Enqueue(ingredient);
            }

            foreach (var freshnessLevel in inputFreshnessLevel)
            {
                freshnessLevels.Push(freshnessLevel);
            }
        }

        private static int GetFreshness(int ingredientValue, int freshnessValue)
        {
            return ingredientValue * freshnessValue;
        }

        private static bool IsDishCooked(int freshness)
        {
            if (dishessFreshnessRequired.ContainsValue(freshness))
            {
                string dishName = dishessFreshnessRequired.First(x => x.Value == freshness).Key;

                cookedDishes[dishName]++;

                return true;
            }

            return false;
        }
        private static bool IsTaskSuccessful(Dictionary<string,int> cookedDishes)
        {
            if (cookedDishes.Count >= 4)
            {
                if (cookedDishes.All(x => x.Value > 0))
                {
                    return true;
                }
            }

            return false;
        }

        private static void PrintCookedDishes(Dictionary<string, int> cookedDishes)
        {
            foreach (var dish in cookedDishes.Where(x => x.Value > 0)
                                                .OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
