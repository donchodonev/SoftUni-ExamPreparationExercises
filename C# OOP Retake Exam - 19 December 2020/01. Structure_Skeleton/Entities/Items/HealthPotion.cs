namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int weight = 5;
        private const double HealPower = 20;
        public HealthPotion() 
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HealPower;
        }
    }
}
