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
        private ICollection<IAstronaut> astronauts;
        private IPlanet planet;

        public Mission()
        {
            astronauts = new List<IAstronaut>();
        }

        public Mission(string name)
        {
            this.name = name;
            astronauts = new List<IAstronaut>();
        }

        public int DeadAstronauts => astronauts.Count(x => !x.CanBreath);

        public IReadOnlyList<IAstronaut> Astronauts => astronauts.ToList().AsReadOnly();

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            this.planet = planet;
            this.astronauts = astronauts;

            foreach (Astronaut astronaut in this.astronauts)
            {
                while (this.planet.Items.Count > 0 && astronaut.CanBreath)
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