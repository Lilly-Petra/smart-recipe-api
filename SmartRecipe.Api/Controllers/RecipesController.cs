using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRecipe.Api.Data;
//using SmartRecipe.Api.Helpers;
using SmartRecipe.Api.Models;

namespace SmartRecipe.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _context.Recipes
                .AsNoTracking()
                .ToListAsync();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe is null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.Name) ||
                string.IsNullOrWhiteSpace(recipe.MainIngredient))
            {
                return BadRequest("Name and MainIngredient are required.");
            }


            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, Recipe recipe)
        {
            // in a real application, you would update the recipe in a database here.
            var recipe2update = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

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

            _context.Recipes.Update(recipe2update);
            await _context.SaveChangesAsync();

            return Ok(recipe2update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            if (recipe is null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
