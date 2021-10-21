namespace Birthday_Celebration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int gramsOfFoodWasted = 0;

            Queue<int> guests = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Guest guest = new Guest();

            while (guests.Count != 0 && plates.Count != 0)
            {
                if (guest.IsGuestFed)
                {
                    guest.RemainingHungerPoints = guests.Peek();
                }

                guest.Eat(plates.Pop());

                if (guest.IsGuestFed)
                {
                    gramsOfFoodWasted += Math.Abs(guest.RemainingHungerPoints);
                    guests.Dequeue();
                }
            }


            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ',plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(' ',guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {gramsOfFoodWasted}");
        }

        public class Guest
        {
            public bool IsGuestFed => RemainingHungerPoints <= 0;
            public int RemainingHungerPoints { get; set; }
            public void Eat(int food)
            {
                RemainingHungerPoints -= food;
            }
        }
    }
}
