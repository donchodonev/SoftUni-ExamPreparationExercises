namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DefaultComfort = 5;
        private const decimal DefaultPrice = 10M;

        public Plant()
            : base(DefaultComfort, DefaultPrice)
        {
        }
    }
}
