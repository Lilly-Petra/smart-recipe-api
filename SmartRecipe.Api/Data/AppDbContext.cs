using Microsoft.EntityFrameworkCore;
using SmartRecipe.Api.Models;

namespace SmartRecipe.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
    }
}
