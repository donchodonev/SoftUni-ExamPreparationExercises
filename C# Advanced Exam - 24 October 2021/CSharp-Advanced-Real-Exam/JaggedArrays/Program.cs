namespace JaggedArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int rows = 8;

            char[][] jaggedArray = new char[rows][];

            Fill(jaggedArray);

            Coordinates white = GetCoordinates('w', jaggedArray);
            Coordinates black = GetCoordinates('b', jaggedArray);

            while (white.Row != 0 && black.Row != 7)
            {
                if (white.Row - 1 == black.Row)
                {
                    if (white.Col - 1 == black.Col || white.Col + 1 == black.Col)
                    {
                        jaggedArray[white.Row][white.Col] = '-';
                        white = black;
                        jaggedArray[white.Row][white.Col] = 'w';
                        Console.WriteLine($"Game over! White capture on {(char)(white.Col + (int)'a')}{8 - white.Row}.");
                        return;
                    }
                }

                jaggedArray[white.Row][white.Col] = '-';

                Move(white, "up");

                jaggedArray[white.Row][white.Col] = 'w';

                if (black.Row + 1 == white.Row)
                {
                    if (black.Col - 1 == white.Col || black.Col + 1 == white.Col)
                    {
                        jaggedArray[black.Row][black.Col] = '-';
                        black = white;
                        jaggedArray[black.Row][black.Col] = 'b';
                        Console.WriteLine($"Game over! Black capture on {(char)((int)'a' + black.Col)}{8 - black.Row}.");
                        return;
                    }
                }

                jaggedArray[black.Row][black.Col] = '-';

                Move(black, "down");

                jaggedArray[black.Row][black.Col] = 'b';
            }

            if (white.Row == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(white.Col + (int)'a')}{8 - white.Row}.");
            }
            else
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)((int)'a' + black.Col)}{8 - black.Row}.");
            }
        }

        /// <summary>
        /// Comapares two sets of coordinates by their row and col value
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>bool</returns>
        public static bool AreCoordinatesEqual(Coordinates first, Coordinates second)
        {
            return first.Equals(second);
        }
        /// <summary>
        /// Prints a jagged array
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="separator">The separator string used when building the column data for each row in the string.Join() static method</param>
        public static void Print(string[][] jaggedArray, string separator)
        {
            foreach (string[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        /// <summary>
        /// Prints a jagged array
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="separator">The separator string used when building the column data for each row in the string.Join() static method</param>
        public static void Print(char[][] jaggedArray, string separator)
        {
            foreach (char[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        /// <summary>
        /// Prints a jagged array
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="separator">The separator string used when building the column data for each row in the string.Join() static method</param>
        public static void Print(int[][] jaggedArray, string separator)
        {
            foreach (int[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        /// <summary>
        /// Checks if the index at row and col position exists
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>bool</returns>
        public static bool IsIndexValid(string[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
        /// <summary>
        /// Checks if the index at row and col position exists
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>bool</returns>
        public static bool IsIndexValid(int[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
        /// <summary>
        /// Checks if the index at row and col position exists
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>bool</returns>
        public static bool IsIndexValid(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
        /// <summary>
        /// For each row in the jagged array - a new line is read from the console and used for the row's column data
        /// </summary>
        /// <param name="jaggedArray"></param>
        public static void Fill(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
        /// <summary>
        /// For each row in the jagged array - a new line is read from the console and used for the row's column data
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="splitSeparator">The separator character of type string</param>
        public static void Fill(string[][] jaggedArray, string splitSeparator = "")
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                         .Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        /// <summary>
        /// For each row in the jagged array - a new line is read from the console and used for the row's column data
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="splitSeparator">The separator character of type string</param>
        public static void Fill(int[][] jaggedArray, string splitSeparator = "")
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                         .Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();
            }
        }

        public class Coordinates : IEquatable<Coordinates>
        {
            public Coordinates()
            {

            }

            public Coordinates(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }

            public bool Equals(Coordinates other)
            {
                return this.Row == other.Row && this.Col == other.Col;
            }
        }
        /// <summary>
        /// Changes the provided coordinates values to match the provided direction
        /// </summary>
        /// <param name="coordinates">Current coordinates</param>
        /// <param name="direction">Direction towards which the coordinates will be adjusted to</param>
        public static void Move(Coordinates coordinates, string direction)
        {
            string directionNormalized = direction.ToLower();

            if (directionNormalized == "up")
            {
                coordinates.Row--;
            }
            if (directionNormalized == "down")
            {
                coordinates.Row++;
            }
            if (directionNormalized == "left")
            {
                coordinates.Col--;
            }
            if (directionNormalized == "right")
            {
                coordinates.Col++;
            }
        }

        public static void MoveOnValidIndex(Coordinates coordinates, string direction, char[][] jaggedArray)
        {
            string directionNormalized = direction.ToLower();

            if (directionNormalized == "up")
            {
                if (IsIndexValid(jaggedArray, coordinates.Row - 1, coordinates.Col))
                {
                    coordinates.Row--;
                }
            }
            if (directionNormalized == "down")
            {
                if (IsIndexValid(jaggedArray, coordinates.Row + 1, coordinates.Col))
                {
                    coordinates.Row++;
                }
            }
            if (directionNormalized == "left")
            {
                if (IsIndexValid(jaggedArray, coordinates.Row, coordinates.Col - 1))
                {
                    coordinates.Col--;
                }
            }
            if (directionNormalized == "right")
            {
                if (IsIndexValid(jaggedArray, coordinates.Row, coordinates.Col + 1))
                {
                    coordinates.Col++;
                }
            }
        }

        public static Coordinates GetCoordinates(char token, char[][] jaggedArray)
        {
            Coordinates coordinates = new Coordinates();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == token)
                    {
                        coordinates.Row = row;
                        coordinates.Col = col;
                    }
                }
            }

            return coordinates;
        }

        public static List<Coordinates> GetCoordinatesList(char token, char[][] jaggedArray)
        {
            List<Coordinates> coordinates = new List<Coordinates>();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == token)
                    {
                        coordinates.Add(new Coordinates(row, col));
                    }
                }
            }

            return coordinates;
        }
    }
}
