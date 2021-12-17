using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRouting.Models
{
    public class RecipeModel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public IngredientModel[] Ingredients { get; set; }


    }
}
