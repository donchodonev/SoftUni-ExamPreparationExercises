using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        private int mana;
        private int hp;

        public Hero(string name, int hp, int mana)
        {
            Name = name;
            this.hp = hp;
            this.mana = mana;
        }

        public bool IsAlive
        {
            get
            {
                if (HP <= 0)
                {
                    return false;
                }

                return true;
            }
        }
        public string Name { get; }

        public int HP
        {
            get => hp;
        }
        public int Mana
        {
            get => mana;
        }

        public void CastSpell(string spellName, int manaNeeded)
        {
            if (manaNeeded <= Mana)
            {
                this.mana -= manaNeeded;
                Console.WriteLine($"{Name} has successfully cast {spellName} and now has {this.mana} MP!");
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough MP to cast {spellName}!");
            }
        }

        public void TakeDamage(int damage, string attacker)
        {
            if (HP > damage)
            {
                this.hp -= damage;
                Console.WriteLine($"{Name} was hit for {damage} HP by {attacker} and now has {HP} HP left!");
            }
            else
            {
                this.hp -= damage;
                Console.WriteLine($"{Name} has been killed by {attacker}!");
            }
        }

        public void Recharge(int amount)
        {
            int initialMana = Mana;

            if (Mana + amount > 200)
            {
                this.mana = 200;
                Console.WriteLine($"{Name} recharged for {200 - initialMana} MP!");
            }
            else
            {
                this.mana += amount;
                Console.WriteLine($"{Name} recharged for {amount} MP!");
            }
        }

        public void Heal(int amount)
        {
            int initialHP = HP;

            if (HP + amount > 100)
            {
                this.hp = 100;
                Console.WriteLine($"{Name} healed for {100 - initialHP} HP!");
            }
            else
            {
                this.hp += amount;
                Console.WriteLine($"{Name} healed for {amount} HP!");
            }
        }

        public override string ToString()
        {
            return $"{Name}" +
                   $"{Environment.NewLine}"+
                   $"  HP: {HP}" +
                   $"{Environment.NewLine}" +
                   $"  MP: {Mana}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroSerialised = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = heroSerialised[0];
                int hp = int.Parse(heroSerialised[1]);
                int mana = int.Parse(heroSerialised[2]);

                heroes.Add(new Hero(name, hp, mana));
            }

            string[] cmdArgs = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "End")
            {
                string heroName = cmdArgs[1];

                if (command == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmdArgs[2]);
                    string spellName = cmdArgs[3];

                    heroes.First(x => x.Name == heroName)
                        .CastSpell(spellName,mpNeeded);
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];

                    heroes.First(x => x.Name == heroName)
                        .TakeDamage(damage,attacker);

                    if (!heroes.First(x => x.Name == heroName).IsAlive)
                    {
                        heroes.Remove(heroes.First(x => x.IsAlive == false));
                    }
                }
                else if (command == "Recharge")
                {
                    int mana = int.Parse(cmdArgs[2]);

                    heroes.First(x => x.Name == heroName)
                        .Recharge(mana);
                }
                else if (command == "Heal")
                {
                    int hp = int.Parse(cmdArgs[2]);

                    heroes.First(x => x.Name == heroName)
                        .Heal(hp);
                }

                cmdArgs = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                command = cmdArgs[0];
            }

            foreach (var hero in heroes
                .OrderByDescending(x => x.HP)
                .ThenBy(x => x.Name))
            {
                Console.WriteLine($"{hero}");
            }
        }
    }
}
