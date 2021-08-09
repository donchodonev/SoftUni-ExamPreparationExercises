using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"([@#])(?'firstWord'[A-Za-z]{3,})\1\1(?'secondWord'[A-Za-z]{3,})\1");

            MatchCollection matches = pattern.Matches(input);

            int validPairs = matches.Count;

            if (validPairs == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validPairs} word pairs found!");
            }

            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                string fWord = match.Groups["firstWord"].Value;
                string sWord = match.Groups["secondWord"].Value;
                char [] secondWordArray = match.Groups["secondWord"].Value.ToCharArray();

                Array.Reverse(secondWordArray);

                string sWordReversed = new string(secondWordArray);

                if (fWord == sWordReversed)
                {
                    mirrorWords.Add($"{match.Groups["firstWord"].Value} <=> {sWord}");
                }
            }

            int mirrorWordsCount = mirrorWords.Count;

            if (mirrorWordsCount == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ",mirrorWords));
            }
        }
    }
}
