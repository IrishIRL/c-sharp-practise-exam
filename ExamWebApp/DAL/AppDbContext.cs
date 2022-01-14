using System;
using System.Linq;
using ExamWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Recipe> Recipes { get; set; } = default!;
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UsersIngredients> UsersIngredients { get; set; } = default!;
        public DbSet<Measurement> Measurement { get; set; } = default!;
        // no cascade delete
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .Where(e => !e.IsOwned())
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        
        // no cascade delete

    }
}