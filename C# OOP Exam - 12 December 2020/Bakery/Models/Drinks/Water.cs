namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal DefaultPrice = 1.50m;

        public Water(string name, int portion, string brand) 
            : base(name, portion, DefaultPrice, brand)
        {
        }
    }
}
