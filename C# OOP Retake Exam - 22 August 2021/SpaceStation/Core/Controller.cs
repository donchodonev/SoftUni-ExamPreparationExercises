using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private List<IAstronaut> unsuitableAstronauts;
        private List<IAstronaut> astronauts;
        private List<IPlanet> planets;
        private int planetsExplored;
        private string[] astronautTypes;
        public Controller()
        {
            unsuitableAstronauts = new List<IAstronaut>();
            astronauts = new List<IAstronaut>();
            planets = new List<IPlanet>();

            var type = typeof(IAstronaut);

            astronautTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(X => X.Name)
                .ToArray();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (!astronautTypes.Contains(type))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            else if (type == "Biologist")
            {
                astronauts.Add(new Biologist(astronautName));
            }
            else if (type == "Meteorologist")
            {
                astronauts.Add(new Meteorologist(astronautName));
            }
            else if (type == "Geodesist")
            {
                astronauts.Add(new Geodesist(astronautName));
            }

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            this.planets.Add(new Planet(planetName, items));

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            if (astronauts.Count(x => x.Oxygen > 60) == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            var planet = planets.First(x => x.Name == planetName);

            Mission mission = new Mission();

            mission.Explore(planet, astronauts.Where(x => x.Oxygen > 60).ToList());

            planetsExplored++;

            int deadAstronautsAfterMission = mission.DeadAstronauts;


            return $"Planet: {planetName} was explored! Exploration" +
                $" finished with" +
                $" {deadAstronautsAfterMission} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{planetsExplored} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronauts.Any(x => x.Name == astronautName))
            {
                astronauts.Remove(astronauts.First(x => x.Name == astronautName));

                return $"Astronaut {astronautName} was retired!";
            }
            else
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
        }
    }
}
