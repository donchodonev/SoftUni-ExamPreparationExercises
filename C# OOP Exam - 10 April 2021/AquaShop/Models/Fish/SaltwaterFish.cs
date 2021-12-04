namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = 5;
        }

        public override void Eat()
        {
            Size += 2;
        }
    }
}
