namespace CocktailParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.All(x => x.Name != ingredient.Name))
            {
                if (Capacity > Ingredients.Count)
                {
                    if (CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
                    {
                        Ingredients.Add(ingredient);
                    }
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = FindIngredient(name);

            if (ingredient == null)
            {
                return false;
            }

            Ingredients.Remove(ingredient);

            return true;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
