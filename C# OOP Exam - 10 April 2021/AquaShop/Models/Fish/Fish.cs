﻿namespace AquaShop.Models.Fish
{
    using AquaShop.Models.Fish.Contracts;
    using System;

    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species,decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Species
        {
            get { return species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                species = value;
            }
        }

        public int Size { get; protected set;}

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                price = value;
            }
        }

        public abstract void Eat();

        public override string ToString()
        {
            return Name;
        }
    }
}
