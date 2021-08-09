using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>>
                pieces = new Dictionary<string, Dictionary<string, string>>();


            int numOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                string name = pieceInfo[0];
                string author = pieceInfo[1];
                string key = pieceInfo[2];

                pieces.Add(name, new Dictionary<string, string>() { { author, key } });
            }

            string[] cmdArgs = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Stop")
            {
                if (command == "Add")
                {
                    string pName = cmdArgs[1];
                    string pAuthor = cmdArgs[2];
                    string pKey = cmdArgs[3];

                    if (pieces.ContainsKey(pName))
                    {
                        Console.WriteLine($"{pName} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(pName, new Dictionary<string, string> { { pAuthor, pKey } });
                        Console.WriteLine($"{pName} by {pAuthor} in {pKey} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string pName = cmdArgs[1];

                    if (pieces.ContainsKey(pName))
                    {
                        pieces.Remove(pName);
                        Console.WriteLine($"Successfully removed {pName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pName} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string pName = cmdArgs[1];

                    if (pieces.ContainsKey(pName))
                    {
                        string newKey = cmdArgs[2];
                        string author = pieces[pName].Keys.Single();

                        Dictionary<string, string> newKeyDict = new Dictionary<string, string> { { author, newKey } };

                        pieces.Remove(pName);
                        pieces.Add(pName, newKeyDict);

                        Console.WriteLine($"Changed the key of {pName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pName} does not exist in the collection.");
                    }
                }

                cmdArgs = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            foreach (var piece in pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value.Keys)
            )
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Keys.Single()}, Key: {piece.Value.Values.Single()}");
            }
        }
    }
}
