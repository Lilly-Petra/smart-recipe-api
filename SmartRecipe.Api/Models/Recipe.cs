namespace SmartRecipe.Api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MainIngredient { get; set; } = string.Empty;
    }
}
