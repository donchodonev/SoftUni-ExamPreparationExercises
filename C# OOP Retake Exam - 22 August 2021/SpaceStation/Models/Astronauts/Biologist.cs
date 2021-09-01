using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name) 
            : base(name)
        {
            SetInitialOxygen();
        }

        public Biologist(double oxygen, string name) 
            : base(oxygen, name)
        {

        }

        protected override void DecreaseOxygen()
        {
            oxygen -= 5;
        }

        protected override void SetInitialOxygen()
        {
            oxygen = 70;
        }
    }
}
