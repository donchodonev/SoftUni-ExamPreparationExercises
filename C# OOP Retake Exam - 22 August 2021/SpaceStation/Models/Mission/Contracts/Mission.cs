using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission.Contracts
{
    public class Mission : IMission
    {
        private string name;
        private List<Astronaut> astronauts;
        private IPlanet planet;
        public Mission(string name)
        {
            this.name = name;
            astronauts = new List<Astronaut>();
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            this.planet = planet;

            foreach (var astronaut in this.astronauts)
            {
                if (astronaut.CanBreath)
                {
                    while (this.planet.Items.Count > 0)
                    {
                        astronaut.Breath();
                        var item = planet.Items.First();
                        astronaut.CollectItem(item);
                        planet.Items.Remove(item);
                    }
                }
            }
        }
    }
}
