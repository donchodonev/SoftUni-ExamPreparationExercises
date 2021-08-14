using System;
using System.Text.RegularExpressions;

namespace _01._Password_Reset
{
    class Program
    {
        static string TakeOdd(string initialString)
        {
            string rawPassword = "";

            for (int i = 0; i < initialString.Length; i++)
            {
                if (i % 2 != 0)
                {
                    rawPassword += initialString[i];
                }
            }

            Console.WriteLine(rawPassword);

            return rawPassword;
        }

        static string Cut(int index, int length, string password)
        {
            string subToRemove = password.Substring(index, length);

            Regex regex = new Regex(@subToRemove);

            string newPwd = regex.Replace(password, "", 1);

            Console.WriteLine(newPwd);

            return newPwd;
        }

        static string Substitute(string substring, string substitute, string rawPassword)
        {
            string newPwd = rawPassword.Replace(substring, substitute);

            if (rawPassword == newPwd)
            {
                Console.WriteLine("Nothing to replace!");
                return rawPassword;
            }
            else
            {
                Console.WriteLine(newPwd);
            }

            return newPwd;
        }

        static void Main(string[] args)
        {
            string rawPassword = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Done")
            {
                if (command == "TakeOdd")
                {
                    rawPassword = TakeOdd(rawPassword);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);

                    rawPassword = Cut(index, length, rawPassword);
                }
                else if (command == "Substitute")
                {
                    string substring = cmdArgs[1];
                    string substitute = cmdArgs[2];

                    rawPassword = Substitute(substring, substitute, rawPassword);
                }

                cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            Console.WriteLine($"Your password is: {rawPassword}");

        }
    }
}
