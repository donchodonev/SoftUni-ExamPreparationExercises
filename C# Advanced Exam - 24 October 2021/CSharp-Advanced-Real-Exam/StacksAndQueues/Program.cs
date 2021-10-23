namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> fruits = new Dictionary<string, List<char>>();

            List<char> pear = "pear".ToCharArray().ToList();
            List<char> flour = "flour".ToCharArray().ToList();
            List<char> pork = "pork".ToCharArray().ToList();
            List<char> olive = "olive".ToCharArray().ToList();

            fruits.Add("pear", pear); ;
            fruits.Add("flour", flour); ;
            fruits.Add("pork", pork); ;
            fruits.Add("olive", olive); ;

            Queue<char> vowels = new Queue<char>();
            Stack<char> consonants = new Stack<char>();

            foreach (var character in Console.ReadLine())
            {
                if (char.IsLetter(character))
                {
                    vowels.Enqueue(character);
                }
            }

            foreach (var character in Console.ReadLine())
            {
                if (char.IsLetter(character))
                {
                    consonants.Push(character);
                }
            }

            while (consonants.Count > 0)
            {
                char vowel = vowels.Peek();
                char consonant = consonants.Pop();

                foreach (var key in fruits.Keys)
                {
                    fruits[key].Remove(vowel);
                    fruits[key].Remove(consonant);
                }

                vowels.Enqueue(vowels.Dequeue());
            }

            int wordsFound = fruits.Where(x => x.Value.Count == 0).Count();

            Console.WriteLine($"Words found: {wordsFound}");

            foreach (var fruit in fruits.Where(x => x.Value.Count == 0))
            {
                Console.WriteLine(fruit.Key);
            }
        }
    }
}
