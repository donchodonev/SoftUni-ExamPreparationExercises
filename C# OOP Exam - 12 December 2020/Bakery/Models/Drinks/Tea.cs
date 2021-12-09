namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal DefaultPrice = 2.50m;
        public Tea(string name, int portion, string brand)
            : base(name, portion, DefaultPrice, brand)
        {
        }
    }
}
