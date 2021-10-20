namespace ExamPreparation
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] jaggedArray = new string[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Entity myself = new Entity();
            Entity opponent = new Entity();

            string command = Console.ReadLine();

            while (command != "Gong")
            {
                var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                if (command.Contains("Find"))
                {
                    Find(myself, jaggedArray, row, col);
                }
                else if (command.Contains("Opponent"))
                {
                    string direction = commandArgs[3];

                    OpponentFind(opponent, jaggedArray, row, col, direction);
                }

                command = Console.ReadLine();
            }

            PrintJaggedArray(jaggedArray);

            Console.WriteLine($"Collected tokens: {myself.Tokens}");
            Console.WriteLine($"Opponent's tokens: {opponent.Tokens}");
        }

        public static bool IsIndexValid(string[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;

        }

        public static bool IsTokenFound(string[][] jaggedArray, int row, int col)
        {
            if (jaggedArray[row][col] == "T")
            {
                return true;
            }
            return false;
        }

        public static void Find(Entity challenger, string[][] jaggedArray, int row, int col)
        {
            if (IsIndexValid(jaggedArray, row, col))
            {
                if (IsTokenFound(jaggedArray, row, col))
                {
                    jaggedArray[row][col] = "-";
                    challenger.Tokens++;
                }
            }
        }

        public static void OpponentFind(Entity opponent, string[][] jaggedArray, int row, int col, string direction)
        {
            int currentOpponentTokens = opponent.Tokens;

            Find(opponent, jaggedArray, row, col);

            if (opponent.Tokens > currentOpponentTokens)
            {
                if (direction == "up")
                {
                    MoveUp(opponent, jaggedArray, row, col);
                }
                if (direction == "down")
                {
                    MoveDown(opponent, jaggedArray, row, col);
                }
                if (direction == "left")
                {
                    MoveLeft(opponent, jaggedArray, row, col);
                }
                if (direction == "right")
                {
                    MoveRight(opponent, jaggedArray, row, col);
                }
            }
        }

        public static void MoveUp(Entity challenger, string[][] jaggedArray, int row, int col, int times = 3)
        {
            for (int i = 1; i <= times; i++)
            {
                Find(challenger, jaggedArray, row - i, col);
            }
        }
        public static void MoveDown(Entity challenger, string[][] jaggedArray, int row, int col, int times = 3)
        {
            for (int i = 1; i <= times; i++)
            {
                Find(challenger, jaggedArray, row + i, col);
            }
        }
        public static void MoveRight(Entity challenger, string[][] jaggedArray, int row, int col, int times = 3)
        {
            for (int i = 1; i <= times; i++)
            {
                Find(challenger, jaggedArray, row, col + i);
            }
        }
        public static void MoveLeft(Entity challenger, string[][] jaggedArray, int row, int col, int times = 3)
        {
            for (int i = 1; i <= times; i++)
            {
                Find(challenger, jaggedArray, row, col - i);
            }
        }

        public static void PrintJaggedArray(string[][] jaggedArray)
        {
            foreach (string[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', col));
            }
        }
    }

    public class Entity
    {
        public int Tokens { get; set; }
    }
}
