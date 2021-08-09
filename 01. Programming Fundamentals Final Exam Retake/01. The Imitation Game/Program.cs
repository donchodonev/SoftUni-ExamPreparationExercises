using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Decode")
            {
                if (command == "Move")
                {
                    Queue rotatedMessage = new Queue();

                    int charsToRotate = int.Parse(cmdArgs[1]);

                    foreach (var character in encryptedMessage)
                    {
                        rotatedMessage.Enqueue(character);
                    }

                    for (int i = 0; i < charsToRotate; i++)
                    {
                        rotatedMessage.Enqueue(rotatedMessage.Dequeue());
                    }

                    encryptedMessage = string.Empty;

                    foreach (var character in rotatedMessage)
                    {
                        encryptedMessage += character;
                    }
                }
                else if (command == "Insert")
                {
                    encryptedMessage = encryptedMessage.Insert(int.Parse(cmdArgs[1]), cmdArgs[2]);
                }
                else if (command == "ChangeAll")
                {
                    encryptedMessage = encryptedMessage.Replace(cmdArgs[1], cmdArgs[2]);
                }

                cmdArgs = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
