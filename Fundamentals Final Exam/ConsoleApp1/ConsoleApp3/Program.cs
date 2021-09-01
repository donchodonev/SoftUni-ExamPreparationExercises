using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static string Case(string username, string cCase)
        {
            string newUsername = string.Empty;

            foreach (var character in username)
            {
                if (cCase == "lower")
                {
                    newUsername += character.ToString().ToLower();
                }
                else
                {
                    newUsername += character.ToString().ToUpper();
                }
            }

            Console.WriteLine(newUsername);
            return newUsername;
        }

        static void Reverse(string username, int startIndex, int endIndex)
        {
            if (startIndex < 0 || startIndex >= username.Length - 1 || endIndex < 0 || endIndex >= username.Length)
            {
                
            }
            else
            {
                string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                string toPrint = string.Empty;

                for (int i = substring.Length - 1; i >= 0; i--)
                {
                    toPrint += substring[i];
                }

                Console.WriteLine(toPrint);
            }
        }

        static string Cut(string username, string substring)
        {
            if (!username.Contains(substring))
            {
                Console.WriteLine($"The word {username} doesn't contain {substring}.");
                return username;
            }

            string newUsername = username.Replace(substring, "");

            Console.WriteLine(newUsername);

            return newUsername;
        }

        static string Replace(string username, char character)
        {
            string newUsername = username.Replace(character,'*');
            Console.WriteLine(newUsername);
            return newUsername;
        }

        static void Check(string username, char character)
        {
            if (username.Contains(character))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {character}.");
            }
        }

        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "Sign")
            {
                string command = cmdArgs[0];

                if (command == "Case")
                {
                    string cCase = cmdArgs[1];

                    username = Case(username, cCase);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    Reverse(username, startIndex, endIndex);
                }
                else if (command == "Cut")
                {
                    string substring = cmdArgs[1];

                    username = Cut(username, substring);
                }
                else if (command == "Replace")
                {
                    char character = char.Parse(cmdArgs[1]);

                    username = Replace(username, character);
                }
                else if (command == "Check")
                {
                    char character = char.Parse(cmdArgs[1]);

                    Check(username, character);
                }

                cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
