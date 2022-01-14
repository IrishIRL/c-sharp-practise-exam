using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamWebApp.Domain
{
    public class Recipe:BaseEntity
    {
        [MaxLength(128)]
        public string ReсipeName { get; set; } = default!;

        [MaxLength(4096)]
        public string Description { get; set; } = default!;

        [MaxLength(128)]
        public string Category { get; set; } = default!;
        
        // amount of portions that this is made for: ex. 1ppl serving, 2ppl serving, 4ppl serving
        public int Servings { get; set; }
        
        // time it takes to prepare such recipe
        public int TimeToReadyMins { get; set; }
        
        public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
    }
}