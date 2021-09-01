using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        public Geodesist(string name) 
            : base(name)
        {
            SetInitialOxygen();
        }

        public Geodesist(double oxygen, string name) 
            : base(oxygen, name)
        {
        }

        protected override void SetInitialOxygen()
        {
            oxygen = 50;
        }
    }
}
