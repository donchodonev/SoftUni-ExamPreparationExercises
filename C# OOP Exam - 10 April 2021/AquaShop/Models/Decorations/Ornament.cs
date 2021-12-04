namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DefaultComfort = 1;
        private const decimal DefaultPrice = 5M;

        public Ornament() 
            : base(DefaultComfort, DefaultPrice)
        {
        }
    }
}
