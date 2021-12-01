namespace Easter.Core.Contracts
{
    using Easter.Models.Bunnies;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Workshops;
    using Easter.Repositories;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                bunnies.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunnies.Add(new SleepyBunny(bunnyName));
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            var dye = new Dye(power);

            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggs.Add(new Egg(eggName, energyRequired));

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var workshop = new Workshop();

            var eligibleBunniesForColoring = bunnies
                .Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (eligibleBunniesForColoring.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            var egg = eggs.FindByName(eggName);

            foreach (var bunny in eligibleBunniesForColoring)
            {
                workshop.Color(egg, bunny);
            }

            var bunniesWithNoEnergy = bunnies
                .Models
                .Where(x => x.Energy == 0)
                .ToList();

            foreach (var bunny in bunniesWithNoEnergy)
            {
                bunnies.Remove(bunny);
            }

            if (egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }

            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var eggsDoneCount = eggs.Models.Where(x => x.IsDone()).Count();

            sb.AppendLine($"{eggsDoneCount} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
