using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = Armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > BaseHealth)
                {
                    health = BaseHealth;
                }

                health = value;

                if (Health == 0)
                {
                    IsAlive = false;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor < hitPoints)
            {
                Armor = 0;

                hitPoints -= Armor;

                Health -= hitPoints;

                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
            else
            {
                Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}