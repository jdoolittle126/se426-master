using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w9_practice_final_1.Models;

namespace w9_practice_final_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {


        private static readonly RecipeModel[] _recipes = new[]
        {
            new RecipeModel()
            {
                Category = "chicken",
                Title = "Chicken Dumpling",
                Instructions = "Cook the Chicken",
                Ingredients = new []
                {
                    new IngredientModel()
                    {
                        Name = "Chicken",
                        Quantity = "1 Whole Chicken"
                    },
                    new IngredientModel()
                    {
                        Name = "Flour",
                        Quantity = "1 Cup"
                    },
                    new IngredientModel()
                    {
                        Name = "Salt",
                        Quantity = "1 Tablespoon"
                    }
                }
            },
            new RecipeModel()
            {
                Category = "chicken",
                Title = "Sweet and Sour Chicken",
                Instructions = "Prepare the chicken with the proper ingredients, serve it over rice",
                Ingredients = new []
                {
                    new IngredientModel()
                    {
                        Name = "Sweet and Sour Chicken",
                        Quantity = "2 Chicken Breasts"
                    },
                    new IngredientModel()
                    {
                        Name = "Pineapple",
                        Quantity = "1 Can"
                    },
                    new IngredientModel()
                    {
                        Name = "Cherries",
                        Quantity = "1 Can"
                    },
                    new IngredientModel()
                    {
                        Name = "Cornstarch",
                        Quantity = "1 Tablespoon"
                    }
                }
            }

        };

        [HttpGet]
        [Route("recipe/{category}")]
        public IEnumerable<RecipeModel> GetRecipesByCategory(string category)
        {
            return _recipes.Where(r => r.Category == category);
        }

    }
}
