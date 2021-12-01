namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using System;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                energyRequired = value;

                if (energyRequired < 0)
                {
                    energyRequired = 0;
                }
            }
        }

        public void GetColored()
        {
            EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return EnergyRequired == 0;
        }
    }
}
