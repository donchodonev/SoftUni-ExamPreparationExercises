namespace Bee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int pollinatedFlowers = 0;

            char[][] jaggedArray = new char[rows][];

            Fill(jaggedArray);

            Coordinates beeCoordinates = new Coordinates();
            Coordinates bonusCoordinates = new Coordinates();
            List<Coordinates> flowersCoordinates = new List<Coordinates>();

            bool isBeeLost = false;

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'B')
                    {
                        beeCoordinates.Row = row;
                        beeCoordinates.Col = col;
                    }
                    else if (jaggedArray[row][col] == 'f')
                    {
                        flowersCoordinates.Add(new Coordinates() { Row = row, Col = col });
                    }
                    else if (jaggedArray[row][col] == 'O')
                    {
                        bonusCoordinates.Row = row;
                        bonusCoordinates.Col = col;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (direction != "End")
            {
                try
                {
                    jaggedArray[beeCoordinates.Row][beeCoordinates.Col] = '.';

                    Move(beeCoordinates, direction);

                    jaggedArray[beeCoordinates.Row][beeCoordinates.Col] = 'B';

                    if (flowersCoordinates.Contains(beeCoordinates))
                    {
                        flowersCoordinates.Remove(beeCoordinates);
                        pollinatedFlowers++;
                    }
                    else if (AreCoordinatesEqual(bonusCoordinates, beeCoordinates))
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    isBeeLost = true;
                    break;
                }

                direction = Console.ReadLine();
            }

            if (isBeeLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            Print(jaggedArray,"");
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
        /// <summary>
        /// Checks if a specific token of type string is found at the specified index
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsTokenFound(string[][] jaggedArray, int row, int col, string token)
        {
            return jaggedArray[row][col] == token;
        }
        /// <summary>
        /// Checks if a specific token of type char is found at the specified index
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsTokenFound(char[][] jaggedArray, int row, int col, char token)
        {
            return jaggedArray[row][col] == token;
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
    }
}
