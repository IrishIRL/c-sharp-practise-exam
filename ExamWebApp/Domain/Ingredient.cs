using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamWebApp.Domain
{
    public class Ingredient:BaseEntity
    {
        [MaxLength(128)]
        public string IngredientName { get; set; } = default!;
        
        [MaxLength(128)]
        public string Category { get; set; } = default!;

        public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
        public ICollection<UsersIngredients>? UsersIngredients { get; set; }
    }
}