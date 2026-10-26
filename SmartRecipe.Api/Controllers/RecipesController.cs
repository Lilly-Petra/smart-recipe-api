using Microsoft.AspNetCore.Mvc;
using SmartRecipe.Api.Helpers;
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
            var recipe = RecipeHelpers.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe is null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult<Recipe> CreateRecipe(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.Name) ||
                string.IsNullOrWhiteSpace(recipe.MainIngredient))
            {
                return BadRequest("Name and MainIngredient are required.");
            }

            int v = RecipeHelpers.Recipes.Max(r => r.Id) + 1;
            recipe.Id = v;
            RecipeHelpers.Recipes.Add(recipe);

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public ActionResult<Recipe> UpdateRecipe(int id, Recipe recipe)
        {
            // in a real application, you would update the recipe in a database here.
            var recipe2update = RecipeHelpers.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe2update is null)
            {
                return NotFound();
            }
            if (string.IsNullOrWhiteSpace(recipe.Name) ||
                string.IsNullOrWhiteSpace(recipe.MainIngredient))
            {
                return BadRequest("Name and MainIngredient are required.");
            }

            recipe2update.Name = recipe.Name;
            recipe2update.MainIngredient = recipe.MainIngredient;

            return Ok(recipe2update);
        }

        [HttpDelete("{id}")]
        public ActionResult<Recipe> DeleteRecipe(int id)
        {
            // in a real application, you would delete the recipe from a database here.
            var recipe = RecipeHelpers.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe is null)
            {
                return NotFound();
            }
            RecipeHelpers.Recipes.Remove(recipe);

            return NoContent();
        }
    }
}
