using SmartRecipe.Api.Models;

namespace SmartRecipe.Api.Helpers
{
    internal static class RecipeHelpers
    {
        public static readonly List<Recipe> Recipes = new()
        {
        new()
        {
            Id = 1,
            Name = "Spaghetti Pomodoro",
            MainIngredient = "Pasta"
        },
        new()
        {
            Id = 2,
            Name = "Mushroom Risotto",
            MainIngredient = "Mushrooms"
        },
        new()
        {
            Id = 3,
            Name = "Chicken Stir Fry",
            MainIngredient = "Chicken"
        }
        };
    }
}