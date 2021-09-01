using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) 
            : base(name)
        {
            SetInitialOxygen();
        }

        public Meteorologist(double oxygen, string name) 
            : base(oxygen, name)
        {
        }

        protected override void SetInitialOxygen()
        {
            oxygen = 90;
        }
    }
}
