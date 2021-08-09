using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var regex = new Regex(@"([|#])(?'product'[a-zA-z\s]+)\1(?'date'\d\d\/\d\d\/\d\d)\1(?'calories'\d{1,5})\1");

            var matches = regex.Matches(input);

            int totalCalories = 0;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int daysToLast = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysToLast} days!");

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {match.Groups["product"].Value}," +
                                  $" Best before: {match.Groups["date"]}," +
                                  $" Nutrition: {match.Groups["calories"]}");
            }
        }
    }
}
