using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeChallenge_Repository
{
    public class CafeContent
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double MealId { get; set; }
        public double Price { get; set; }

        public CafeContent() { }
        public CafeContent(string mealName, string description, string ingredients, double mealId, double price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            MealId = mealId;
            Price = price;
        }
    }
}