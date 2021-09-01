using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;
        public Planet(string name)
        {
            SetName(name);
            items = new List<string>();
        }

        public ICollection<string> Items => this.items.AsReadOnly();

        public string Name => this.name;

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name!");
            }
            this.name = name;
        }
    }
}
