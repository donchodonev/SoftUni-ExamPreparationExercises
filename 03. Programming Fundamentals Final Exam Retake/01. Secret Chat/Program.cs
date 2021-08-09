using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        public static string InsertSpace(string message, int index)
        {
            return message.Insert(index, " ");
        }
        public static string Reverse(string message, string substring)
        {
            if (message.Contains(substring))
            {
                int startIndex = message.IndexOf(substring);
                message = message.Remove(startIndex, substring.Length);

                foreach (var character in substring.Reverse())
                {
                    message += character;
                }

                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("error");
            }

            return message;
        }
        public static string ChangeAll(string message, string substring, string replacement)
        {
            return message.Replace(substring, replacement);
        }
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Reveal")
            {
                if (command == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);

                    concealedMessage = InsertSpace(concealedMessage, index);

                    Console.WriteLine(concealedMessage);
                }
                else if (command == "Reverse")
                {
                    string substring = cmdArgs[1];
                    concealedMessage = Reverse(concealedMessage, substring);
                }
                else
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];
                    concealedMessage = ChangeAll(concealedMessage, substring, replacement);
                    Console.WriteLine(concealedMessage);
                }


                cmdArgs = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                command = cmdArgs[0];
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
