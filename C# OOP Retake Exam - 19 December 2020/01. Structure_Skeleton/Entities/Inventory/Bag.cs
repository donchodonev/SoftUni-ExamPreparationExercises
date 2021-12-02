namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarCroft.Entities.Items;

    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var itemToRemove = Items.FirstOrDefault(x => x.GetType().Name == name);

            if (itemToRemove == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(itemToRemove);

            return itemToRemove;
        }
    }
}
