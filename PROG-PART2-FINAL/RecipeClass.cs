using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_PART2_FINAL
{
    internal class RecipeClass
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Instructions { get; set; } = new List<string>();
        public double TotalCalories
        {
            get
            {
                return Ingredients.Sum(ingredient => ingredient.Calories);
            }
        }
    }
}