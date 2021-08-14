using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        class Dwarf
        {
            public Dwarf(string name, string color, int physics)
            {
                Name = name;
                Color = color;
                Physics = physics;
            }
            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }

            public override string ToString()
            {
                return $"({Color}) {Name} <-> {Physics}";
            }
        }
        static void Main(string[] args)
        {
            List<Dwarf> dwarves = new List<Dwarf>();

            string[] dwarfAttr = Console.ReadLine()
                .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

            while (dwarfAttr[0] != "Once upon a time")
            {
                string name = dwarfAttr[0];
                string color = dwarfAttr[1];
                int physics = int.Parse(dwarfAttr[2]);

                if (dwarves.All(x => x.Name != name))
                {
                    dwarves.Add(new Dwarf(name, color, physics));
                }
                else if (dwarves.Any(x => x.Name == name))
                {
                    if (dwarves.First(x => x.Name == name).Color != color)
                    {
                        dwarves.Add(new Dwarf(name, color, physics));
                    }
                    else
                    {
                        if (dwarves.First(x => x.Name == name).Physics < physics)
                        {
                            dwarves.Remove(dwarves.First(x => x.Name == name && x.Color == color));
                            dwarves.Add(new Dwarf(name, color, physics));
                        }
                    }
                }

                dwarfAttr = Console.ReadLine()
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var dwarf in dwarves
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => dwarves.Count(y => y.Color == x.Color)))
            {
                Console.WriteLine(dwarf);
            }
        }
    }
}
