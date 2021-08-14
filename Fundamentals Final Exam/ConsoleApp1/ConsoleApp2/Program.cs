using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();

                Regex regex = new Regex(@"(.+)>(?'numbers'[0-9]{3})\|(?'lowerLetters'[a-z]{3})\|(?'upperLetters'[A-Z]{3})\|(?'symbols'[^<>]{3})<\1");

                if (regex.IsMatch(password))
                {
                    var match = regex.Match(password);

                    string newPwd = String.Empty;

                    newPwd += match.Groups["numbers"].Value;
                    newPwd += match.Groups["lowerLetters"].Value;
                    newPwd += match.Groups["upperLetters"].Value;
                    newPwd += match.Groups["symbols"].Value;

                    Console.WriteLine($"Password: {newPwd}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
