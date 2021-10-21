namespace Super_Mario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[rows][];

            Fill(jaggedArray);

            Coordinates marioCoordinates = GetCoordinates(jaggedArray, 'M');
            Coordinates princessCoordinates = GetCoordinates(jaggedArray, 'P');
            List<Coordinates> bowserCoordinates = GetCoordinateList(jaggedArray, 'B');

            jaggedArray[marioCoordinates.Row][marioCoordinates.Col] = '-';

            char[] playArgs = Console.ReadLine()
                .Where(char.IsLetterOrDigit)
                .ToArray();

            bool isPrincessFound = false;

            while (!isPrincessFound)
            {
                char direction = playArgs[0];
                int row = int.Parse(playArgs[1].ToString());
                int col = int.Parse(playArgs[2].ToString());

                //update Bowser coorinates list
                bowserCoordinates.Add(new Coordinates() { Row = row, Col = col });

                //update map with Bowsers
                foreach (var bc in bowserCoordinates)
                {
                    jaggedArray[bc.Row][bc.Col] = 'B';
                }

                if (direction == 'W')
                {
                    if (IsIndexValid(jaggedArray,marioCoordinates.Row - 1,marioCoordinates.Col))
                    {
                        Move(marioCoordinates,direction);
                    }
                }
                else if (direction == 'S')
                {
                    if (IsIndexValid(jaggedArray, marioCoordinates.Row + 1, marioCoordinates.Col))
                    {
                        Move(marioCoordinates, direction);
                    }
                }
                else if (direction == 'A')
                {
                    if (IsIndexValid(jaggedArray, marioCoordinates.Row, marioCoordinates.Col - 1))
                    {
                        Move(marioCoordinates, direction);
                    }
                }
                else if (direction == 'D')
                {
                    if (IsIndexValid(jaggedArray, marioCoordinates.Row, marioCoordinates.Col + 1))
                    {
                        Move(marioCoordinates, direction);
                    }
                }

                 lives--;

                if (AreCoordinatesEqual(marioCoordinates, princessCoordinates))
                {
                    isPrincessFound = true;
                    jaggedArray[princessCoordinates.Row][princessCoordinates.Col] = '-';
                    break;
                }

                if (lives <= 0)
                {
                    jaggedArray[marioCoordinates.Row][marioCoordinates.Col] = 'X';
                    break;
                }

                foreach (var bc in bowserCoordinates)
                {
                    if (AreCoordinatesEqual(marioCoordinates,bc))
                    {
                        lives -= 2;

                        if (lives <= 0)
                        {
                            jaggedArray[marioCoordinates.Row][marioCoordinates.Col] = 'X';
                        }
                        else
                        {
                            jaggedArray[marioCoordinates.Row][marioCoordinates.Col] = '-';
                        }

                        bowserCoordinates.Remove(bc);
                        break;
                    }
                }

                playArgs = Console.ReadLine()
                .ToArray()
                .Where(char.IsLetterOrDigit)
                .ToArray();
            }

            if (isPrincessFound)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioCoordinates.Row};{marioCoordinates.Col}.");
            }

            Print(jaggedArray,"");
        }

        public static bool AreCoordinatesEqual(Coordinates first, Coordinates second)
        {
            return first.Equals(second);
        }
        public static void Print(char[][] jaggedArray, string separator)
        {
            foreach (char[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        public static bool IsIndexValid(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
        public static void Fill(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
        public class Coordinates : IEquatable<Coordinates>
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public bool Equals(Coordinates other)
            {
                return this.Row == other.Row && this.Col == other.Col;
            }
        }
        public static void Move(Coordinates coordinates, char direction)
        {
            string directionNormalized = direction.ToString().ToLower();

            if (directionNormalized == "w")
            {
                coordinates.Row--;
            }
            if (directionNormalized == "s")
            {
                coordinates.Row++;
            }
            if (directionNormalized == "a")
            {
                coordinates.Col--;
            }
            if (directionNormalized == "d")
            {
                coordinates.Col++;
            }
        }
        public static Coordinates GetCoordinates(char[][] jaggedArray, char token)
        {
            Coordinates coordinates = null;

            for (int row = 0; row < jaggedArray.Length && coordinates == null; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length && coordinates == null; col++)
                {
                    if (jaggedArray[row][col] == token)
                    {
                        coordinates = new Coordinates();
                        coordinates.Row = row;
                        coordinates.Col = col;
                    }
                }
            }

            return coordinates;
        }
        public static List<Coordinates> GetCoordinateList(char[][] jaggedArray, char token)
        {
            List<Coordinates> coordinates = new List<Coordinates>();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == token)
                    {
                        coordinates.Add(new Coordinates() { Row = row, Col = col });
                    }
                }
            }

            return coordinates;
        }
    }
}
