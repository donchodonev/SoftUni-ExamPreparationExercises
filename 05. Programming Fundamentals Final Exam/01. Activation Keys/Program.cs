using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Contains(string key, string substring)
        {

            if (key.Contains(substring))
            {
                Console.WriteLine($"{key} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        static string Flip(string cCase, int start, int end, string key)
        {
            string newKey = string.Empty;

            for (int i = 0; i < key.Length; i++)
            {
                if (i >= start && i < end)
                {
                    if (cCase == "Upper")
                    {
                        newKey += key[i].ToString().ToUpper();
                    }
                    else
                    {
                        newKey += key[i].ToString().ToLower();
                    }
                }
                else
                {
                    newKey += key[i];
                }
            }

            Console.WriteLine(newKey);

            return newKey;
        }

        static string Slice(int start, int end, string key)
        {
            string newKey = key.Remove(start, end - start);

            Console.WriteLine(newKey);

            return newKey;
        }

        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Generate")
            {
                string substring = cmdArgs[1];

                if (command == "Contains")
                {
                    Contains(key, substring);
                }
                else if (command == "Flip")
                {
                    string cCase = cmdArgs[1];
                    int start = int.Parse(cmdArgs[2]);
                    int end = int.Parse(cmdArgs[3]);

                    key = Flip(cCase, start, end, key);
                }
                else if (command == "Slice")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int end = int.Parse(cmdArgs[2]);

                    key = Slice(start, end, key);
                }

                cmdArgs = Console.ReadLine()
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
