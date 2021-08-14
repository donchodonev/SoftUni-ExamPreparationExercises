using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static long GetCoolness(string word)
        {
            long coolness = 0;

            foreach (var character in word)
            {
                if (char.IsLetter(character))
                {
                    coolness += (long)character;
                }
            }

            return coolness;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(::|\*\*)(?'word'[A-Z][a-z]{2,})\1");

            var matchCollection = regex.Matches(input);

            List<string> words = new List<string>();

            foreach (Match match in matchCollection)
            {
                words.Add(match.Value);
            }

            long coolThreshold = 1;

            foreach (var character in input)
            {
                if (char.IsDigit(character))
                {
                    coolThreshold *= long.Parse(character.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{words.Count} emojis found in the text. The cool ones are:");

            foreach (var word in words)
            {
                if (GetCoolness(word) > coolThreshold)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}