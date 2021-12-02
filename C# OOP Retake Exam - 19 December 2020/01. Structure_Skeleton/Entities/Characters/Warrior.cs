﻿namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double DefaultBaseHealth = 100;
        private const double DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;
        private static Bag DefaultBagType;

        public Warrior(string name)
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, DefaultBagType)
        {
            DefaultBagType = new Satchel();
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
