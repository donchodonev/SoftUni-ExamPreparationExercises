using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name = "";
        protected double oxygen;

        public Astronaut(string name)
        {
            GetName(name);
        }

        public Astronaut(double oxygen, string name)
            :this(name)
        {
            IncreaseOxygen(oxygen);
        }

        public string Name => this.name;

        public double Oxygen => this.oxygen;

        public bool CanBreath => Oxygen > 0;

        public IBag Bag => throw new NotImplementedException();

        public void Breath()
        {
            DecreaseOxygen();
        }

        private void GetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Astronaut name cannot be null or empty.");
            }

            this.name = name;
        }

        private void IncreaseOxygen(double oxygen)
        {
            if (oxygen < 0)
            {
                throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
            }

            this.oxygen += oxygen;
        }

        protected virtual void DecreaseOxygen()
        {
            oxygen -= 10;
        }

        protected abstract void SetInitialOxygen();
    }
}
