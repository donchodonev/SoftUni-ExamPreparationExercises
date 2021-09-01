﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags.Contracts
{
    public class Backpack : IBag
    {
        private List<string> items;
        public Backpack()
        {
            items = new List<string>();
        }
        public ICollection<string> Items => this.items;
    }
}
