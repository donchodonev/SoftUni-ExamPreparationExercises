namespace ExamPreparation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Army army = new Army(int.Parse(Console.ReadLine()));

            int mapRows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[mapRows][];

            Fill(jaggedArray);

            List<Coordinates> orcCoordinates = GetInitialOrcCoordinates(jaggedArray);

            army.Coordinates = GetArmyCoordinates(jaggedArray);

            jaggedArray[army.Coordinates.Row][army.Coordinates.Col] = '-';

            Coordinates mordorCoordinates = GetMordorCoordinates(jaggedArray);
            
            var cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (true)
            {
                string direction = cmdArgs[0];

                int orcSpawnRow = int.Parse(cmdArgs[1]);
                int orcSpawnCol = int.Parse(cmdArgs[2]);

                SpawnOrcs(orcSpawnRow, orcSpawnCol, jaggedArray);

                orcCoordinates.Add(new Coordinates() { Row = orcSpawnRow, Col = orcSpawnCol });

                MoveArmy(army,direction,jaggedArray);

                if (army.Coordinates.Equals(mordorCoordinates))
                {
                    army.ReachedMordor = true;
                }
                else if (orcCoordinates.Contains(army.Coordinates))
                {
                    army.DecreaseArmorBy(2);
                }

                MarkBattle(jaggedArray,army.Coordinates.Row,army.Coordinates.Col);


                if (army.ReachedMordor)
                {
                    jaggedArray[army.Coordinates.Row][army.Coordinates.Col] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {army.Armor}");
                    break;
                }
                else if (army.IsArmorBroken)
                {
                    jaggedArray[army.Coordinates.Row][army.Coordinates.Col] = 'X';
                    Console.WriteLine($"The army was defeated at {army.Coordinates.Row};{army.Coordinates.Col}.");
                    break;
                }

                cmdArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Print(jaggedArray,"");
        }

        public static void MoveArmy(Army army, string direction, char[][]map)
        {
            if (direction == "up")
            {
                if (IsIndexValid(map, army.Coordinates.Row - 1, army.Coordinates.Col))
                {
                    army.MoveUp();
                }
                army.DecreaseArmorBy(1);
            }
            else if (direction == "down")
            {
                if (IsIndexValid(map, army.Coordinates.Row + 1, army.Coordinates.Col))
                {
                    army.MoveDown();
                }
                army.DecreaseArmorBy(1);
            }
            else if (direction == "left")
            {
                if (IsIndexValid(map, army.Coordinates.Row, army.Coordinates.Col - 1))
                {
                    army.MoveLeft();
                }
                army.DecreaseArmorBy(1);
            }
            else if (direction == "right")
            {
                if (IsIndexValid(map, army.Coordinates.Row, army.Coordinates.Col + 1))
                {
                    army.MoveRight();
                }

                army.DecreaseArmorBy(1);
            }
        }
        public static List<Coordinates> GetInitialOrcCoordinates(char[][] jaggedArray)
        {
            List<Coordinates> orcCoordinates = new List<Coordinates>();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'O')
                    {
                        orcCoordinates.Add(new Coordinates { Row = row, Col = col});
                    }
                }
            }

            return orcCoordinates;
        }
        public static void MarkBattle(char[][] jaggedArray,int row,int col)
        {
            jaggedArray[row][col] = '-';
        }
        public static void SpawnOrcs(int row, int col, char[][] jaggedArray)
        {
            jaggedArray[row][col] = 'O';
        }
        public static Coordinates GetArmyCoordinates(char[][] jaggedArray)
        {
            var coordinates = new Coordinates();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'A')
                    {
                        coordinates.Row = row;
                        coordinates.Col = col;
                    }
                }
            }
            return coordinates;
        }
        public static Coordinates GetMordorCoordinates(char[][] jaggedArray)
        {
            var coordinates = new Coordinates();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'M')
                    {
                        coordinates.Row = row;
                        coordinates.Col = col;
                    }
                }
            }
            return coordinates;
        }
        public static void Print(char[][] jaggedArray, string separator)
        {
            foreach (char[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        public static void Fill(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
        public static bool IsIndexValid(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
    }
    public class Army
    {
        public Army(int armor)
        {
            Armor = armor;
            Coordinates = new Coordinates();
        }

        public int Armor { get; set; }

        public void DecreaseArmorBy(int offset)
        {
            Armor -= offset;
        }

        public bool ReachedMordor { get; set; }

        public bool IsArmorBroken => Armor <= 0;

        public Coordinates Coordinates { get; set; }

        public void MoveUp()
        {
            Coordinates.Row--;
        }
        public void MoveDown()
        {
            Coordinates.Row++;
        }
        public void MoveRight()
        {
            Coordinates.Col++;
        }
        public void MoveLeft()
        {
            Coordinates.Col--;
        }
    }

    public class Coordinates :IEquatable<Coordinates>
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public bool Equals(Coordinates other)
        {
            return this.Row == other.Row && this.Col == other.Col;
        }
    }
}
