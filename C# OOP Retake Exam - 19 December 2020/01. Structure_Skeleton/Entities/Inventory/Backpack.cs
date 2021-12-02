namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int DefualtCapacity = 100;

        public Backpack() 
            : base(DefualtCapacity)
        {
        }
    }
}
