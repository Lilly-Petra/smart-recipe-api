using Microsoft.AspNetCore.Mvc;
using SmartRecipe.Api.Models;

namespace SmartRecipe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            var recipes = new List<Recipe>
            {
                new() { Id = 1, Name = "Spaghetti Pomodoro", MainIngredient = "Pasta" },
                new() { Id = 2, Name = "Mushroom Risotto", MainIngredient = "Mushrooms" },
                new() { Id = 3, Name = "Chicken Stir Fry", MainIngredient = "Chicken" }
            };
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            var recipe = new Recipe { Id = id, Name = "Sample Recipe", MainIngredient = "Sample Ingredient" };
            return Ok(recipe);
        }
        /*
                [HttpPost]
                public ActionResult<Recipe> CreateRecipe(Recipe recipe)
                {
                    // In a real application, you would save the recipe to a database here.
                    recipe.Id = new Random().Next(1000); // Simulate ID generation
                    return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
                }

                [HttpPut("{id}")]
                public ActionResult<Recipe> UpdateRecipe(int id, Recipe recipe)
                {
                    // In a real application, you would update the recipe in a database here.
                    recipe.Id = id; // Ensure the ID is set correctly
                    return Ok(recipe);
                }

                [HttpDelete("{id}")]
                public ActionResult<Recipe> DeleteRecipe(int id)
                {
                    // In a real application, you would delete the recipe from a database here.
                    return Ok();
                }
        */
    }
}
