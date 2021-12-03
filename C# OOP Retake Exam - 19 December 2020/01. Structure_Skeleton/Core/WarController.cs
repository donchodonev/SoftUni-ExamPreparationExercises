using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty;
        private Stack<Item> itemPool;

        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new Stack<Item>();
        }

        //string characterType, string name

        public string JoinParty(string[] args)
        {
            string characterType = args.First();
            string characterName = args.Last();

            Character character;

            if (characterType == "Warrior")
            {
                character = new Warrior(characterName);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(characterName);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            characterParty.Add(character);

            return $"{characterName} joined the party!";
        }

        //itemName
        public string AddItemToPool(string[] args)
        {
            string itemName = args.First();

            Item item;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            itemPool.Push(item);

            return $"{itemName} added to pool.";
        }

        //characterName
        public string PickUpItem(string[] args)
        {
            string characterName = args.First();

            Character character = characterParty
                .FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var lastItem = itemPool.Pop();

            character.Bag.AddItem(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        //characterName, itemName
        public string UseItem(string[] args)
        {
            string characterName = args.First();
            string itemName = args.Last();

            Character character = characterParty.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                item = new HealthPotion();
            }

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characterParty
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        //attackerName, receiverName
        public string Attack(string[] args)
        {
            string attackerName = args.First();
            string receiverName = args.Last();

            Warrior attacker = characterParty
                .FirstOrDefault(x => x.Name == attackerName) as Warrior;

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            Character receiver = characterParty
                .FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            string healerName = args.First();
            string receiverName = args.Last();

            Priest healer = characterParty
                .FirstOrDefault(x => x.Name == healerName) as Priest;

            if (healerName == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            Character receiver = characterParty
                .FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healer.Heal(receiver);

            return $"{healerName} heals {receiverName} for {healer.AbilityPoints}! {receiverName} has {receiver.Health} health now!";
        }
    }
}
