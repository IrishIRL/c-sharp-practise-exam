using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Domain
{
    // not sure whether MeasurementId should be here 
    [Index(new[] {nameof(RecipeId), nameof(IngredientId)}, IsUnique = true)]
    public class RecipeIngredient:BaseEntity
    {
        //[MaxLength(255)]
        //public string Comment { get; set; } = default!;
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        
        public float Quantity { get; set; }
        public int MeasurementId { get; set; }
        public Measurement? Measurement { get; set; }
    }
}