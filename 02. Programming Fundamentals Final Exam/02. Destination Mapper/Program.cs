using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLocations = Console.ReadLine();

            Regex regex = new Regex(@"([=\/])(?'location'[A-Z][A-Za-z]{2,})\1");

            var matchCollection = regex.Matches(inputLocations);

            List<string> destionations = new List<string>();

            int travelPoints = 0;

            foreach (Match match in matchCollection)
            {
                destionations.Add(match.Groups["location"].Value);
                travelPoints += match.Groups["location"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ",destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
