namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        private const int weight = 5;
        private const double Damage = 20;

        public FirePotion()
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= Damage;
        }
    }
}
